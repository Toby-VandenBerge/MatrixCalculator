Matrix Calculator
============
CommandLine utility to populate NxM matrix and then print out the data.

Building
============
### Clone Repo
```
git clone https://github.com/Toby-VandenBerge/Arithmetic.Evaluation.git
```

### Build
Utilizes [Cake](https://github.com/cake-build/cake) to execute the compilation and tests
```
cd MatrixCalculator
powershell .\build.ps1
```

Running
============
### Execution
Navigate to .\src\InterviewMatrix\bin\Release\
Execute 
```
.\InterviewMatrix.exe
```
specifying the arguments of your choice

### Arguments
#### Verbs
* AlphaMatrix
	* w, Width (Width of the matrix)
	* h, Height (Height of the matrix)
	* t, Traverse (Traverse Orientation of the matrix. One of [TopToBottom]