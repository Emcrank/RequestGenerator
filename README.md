# Introduction 
This app allows the generation of requests including the use of a template file while allowing variables to be provided via input files (currently only csv).

# Features in Bullets
- Multiple types of requests to be generated including generation of files from a template.
- Allows variables in the template to be replaced with data from an input file on generation.
- Allows setting of each generated file's filename.
- Allows throttling generation of the files based on a **requests per minute** figure provided by the user.

# Quickstart
1. Prepare your template file (if required)
2. Prepare your input file (if required)
4. Run the application
5. Configure the requests to be generated.
5. Click Generate to start.

# Templated File Request
A template file is a file that is used as a base for the content of the generated files. It may contain variables inside in the format of `#{variable}`
- It must be placed in the startup directory of the executable.
- It must be named `Template.reqgentemplate`
Currently the app only supports csv format. There are some requirements:
- The first line must contain the names of the variables as headers
- It must be placed in the startup directory of the executable.

#### Example Input File:
```
Id,Name
11,AAA
22,MMM
33,XXX
44,QQQ
55,YYY
66,BBB
77,YYY
88,CCC
99,ZZZ
```