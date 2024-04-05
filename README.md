# Introduction 
This console app allows the generation of files using the content of a template file while allowing variables to be provided via a input file (currently only csv).

# Features in Bullets
- Allows generation of files from a template.
- Allows variables in the template to be replaced with data from an input file on generation.
- Allows setting of each generated file's filename.
- Allows throttling generation of the files based on a **requests per minute** figure provided by the user.

# Quickstart
1. Prepare your template file.
2. Prepare your input file (if required)
3. Place template file & input file in same directory as the executable.
4. Run the executable
5. Follow the instructions & answer questions on the console.

# Template File
The template file is the file that is used as a base for the content of the generated files. It may contain variables inside in the format of `#{variable}`
- It must be placed in the startup directory of the executable.
- It must be named `Template.reqgentemplate`
#### Snippet of variables in a Template File:
```
<ExampleXml>
  <Id>#{Id}</Id>
  <Name>#{Name}</Name>
  <MessageType>Foobar</MessageType>
  ...
```

# Input File
Currently the app only supports csv format. There are some requirements:
- The first line must contain the names of the variables as headers
- It must be placed in the startup directory of the executable.
- It must be named `InputFile.csv`

#### Note: If your template file does not contain any variables then the application will not attempt to load an input file.

#### Example Input File:
```
Id,Name
111111111,AAA
222222222,MMM
333333333,XXX
444444444,QQQ
555555555,YYY
666666666,BBB
777777777,YYY
888888888,CCC
999999999,ZZZ
```