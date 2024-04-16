using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using RequestGenerator.Logic;
using RequestGenerator.Logic.Requests;
using RequestGenerator.WPFApp.Commands;
using RequestGenerator.WPFApp.Services;
using RequestGenerator.WPFApp.Views;

namespace RequestGenerator.WPFApp.ViewModels.Pages;

public class ObservableLogMessageCollection : ObservableCollection<string>
{
    /// <summary>Inserts an item into the collection at the specified index.</summary>
    /// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
    /// <param name="item">The object to insert.</param>
    protected override void InsertItem(int index, string item)
    {
        base.InsertItem(index, $"{DateTime.Now:dd-MM-yyy HH:mm:ss.fff} | {item}");
    }

    /// <summary>Replaces the element at the specified index.</summary>
    /// <param name="index">The zero-based index of the element to replace.</param>
    /// <param name="item">The new value for the element at the specified index.</param>
    protected override void SetItem(int index, string item)
    {
        base.SetItem(index, $"{DateTime.Now:dd-MM-yyy HH:mm:ss.fff} | {item}");
    }
}

public class MainViewModel : ObservableObject
{
    private readonly RequestGenerationOrchestrator generationOrchestrator = new();
    private readonly MainWindow mainWindow;

    private CancellationTokenSource? cancellationTokenSource;

    private bool isGenerating;

    public MainViewModel(MainWindow mainWindow)
    {
        this.mainWindow = mainWindow;

        generationOrchestrator.LogMessageProduced += (_, s) => LogMessage(s);

        GenerateCommand = new RelayCommand(
            _ => Generate(),
            _ => Requests.Count > 0 && !IsGenerating);

        CancelGenerateCommand = new RelayCommand(
            _ => CancelGenerate(),
            _ => IsGenerating);

        AddRequestCommand = new RelayCommand(_ => AddRequest());
        EditRequestCommand = new RelayCommand(EditRequest);
        DeleteRequestCommand = new RelayCommand(DeleteRequest);
    }

    public bool IsGenerating
    {
        get => isGenerating;
        set => SetField(ref isGenerating, value);
    }

    public ObservableLogMessageCollection LogMessages { get; } = new()
    {
        "Request Generator",
        "Step 1 - Configure the types of requests you wish to generate.",
        "Step 2 - Enter RPM and the output directory.",
        "Step 3 - Hit Generate.",
        "----------------------------------------------------------------"
    };

    public ICommand EditRequestCommand { get; }

    public ICommand GenerateCommand { get; }

    public ICommand AddRequestCommand { get; }

    public ICommand DeleteRequestCommand { get; }

    public ICommand CancelGenerateCommand { get; }

    public string? OutputDirectory { get; set; }

    public string? RequestsPerMinuteInput { get; set; } = "*";

    public ObservableCollection<Request> Requests { get; } = new();

    private void AddRequest()
    {
        var selectionWindow = new RequestSelectionWindow { Owner = mainWindow };
        if (!selectionWindow.ShowDialog() ?? false)
            return;

        var editWindow = selectionWindow.ChosenWindow;
        if (editWindow == null)
            return;

        editWindow.Owner = mainWindow;
        if (editWindow.ShowDialog() == true)
            Requests.Add((Request)editWindow.DataContext);
    }

    private void CancelGenerate()
    {
        cancellationTokenSource?.Cancel();
        cancellationTokenSource?.Dispose();
        cancellationTokenSource = null;
    }

    private void DeleteRequest(object? selectedItem)
    {
        if (selectedItem == null)
            return;

        Requests.Remove((Request)selectedItem);
    }

    private void EditRequest(object? selectedItem)
    {
        if (selectedItem == null)
            return;

        var editWindow = RequestEditWindowFactory.CreateWindow(selectedItem.GetType().Name);
        editWindow.Owner = mainWindow;
        editWindow.DataContext = selectedItem;
        editWindow.ShowDialog();
    }

    private async void Generate()
    {
        using (cancellationTokenSource = new CancellationTokenSource())
        {
            IsGenerating = true;
            LogMessages.Clear();

            try
            {
                PreGenerationValidation();

                int? requestsPerMinute = RequestsPerMinuteInput == "*" ? null : int.Parse(RequestsPerMinuteInput!);

                var options = new RequestGenerationOrchestratorOptions
                {
                    Destination = OutputDirectory!,
                    RequestsPerMinute = requestsPerMinute
                };

                await generationOrchestrator.GenerateRequestsAsync(Requests, options, cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                LogMessages.Add(ex.Message);
            }
            finally
            {
                IsGenerating = false;
            }
        }

        cancellationTokenSource = null;
    }

    private void LogMessage(string message)
    {
        Application.Current.Dispatcher.Invoke(() => LogMessages.Add(message));
    }

    private void PreGenerationValidation()
    {
        if (string.IsNullOrWhiteSpace(RequestsPerMinuteInput))
            throw new InvalidOperationException("Invalid requests per minute. Must be a number or *");
    }
}