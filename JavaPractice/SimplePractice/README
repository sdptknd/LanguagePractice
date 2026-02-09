This is the root directory, run any command from this directory.

# How to run java files:

First use the below command to give executable access to run.sh file:

`chmod +x run.sh `

Then run the below command:

`./run.sh <path_to_java_file_containing_main>`


example: `./run.sh src/main/java/com/sid/myapp/Important.java`

# Let's understand what's happening in run.sh file:

How java compilation and run work:

1. `javac` command is used for java compilation. `-d` option can be provided to tell java where to keep the compiled bytecode/.class files. If `-d` not provided, then complied files will be adjacent to java files as each java file will be compiled to a .class file. While compilicing, java creates the folder structure exactly same as package name. For example, in Important.java file, the package name is `main.java.com.sid.myapp`, so the Important.java's compiled file, Important.class will be kept at `main/java/com/sid/myapp/` location. `-cp` option is to provide class path, that means from where to look for the class files or the package. So to compile Important.java file and keep it in `out/` folder, the command will be `javac -d out/ -cp "out/:lib/*" src/main/java/com/sid/myapp/Important.java`. Remember, `-cp "out/:lib/*"` is not required in the above example because Important.java file isn't using any package/class which will be found in out/ or in any .jar in lib/. However, this is a tiresome way to compile java files as we have to compile all java files one at a time.

2. `java` command is used to run compiled byte code. As parameter, the class file's package path is provided.  `-cp` option is to provide class path, that means from where to look for the class files or the package. So the command will be `java -cp 'out/' main.java.com.sid.myapp.Important`. Again, remember, java treats package structure as folder structure in file-system.

3. So, `run.sh` does all of the above with a bit of smartness. It first clears all existing class files from `out/` directory. Then it takes all the arguments in args array. Then it compiles all `.class` files inside src directory and put them in `out/` directory, so that all dependency files also get compiled. Then it run the class file after removing `src/` directory prefix and replacing `/` with `.` for package notation. Example, `src/main/java/com/sid/myapp/Important.java` becomes `main.java.com.sid.myapp.Important`. Both in javac and java command it uses `-cp` directing to `out/` and `lib/*` directories to refer to required classes from `out/` directory and from any `.jar` file from `lib/` directory (third party library). However, still this might fail, let's say file A.java requires B.java, but A.java is getting compiled first, so it wonn't get reference of B.java's class file.


To avoid all this complexity, use gradle or maven.


## An interesting fact with TestFact.java:

We can run `./run.sh src/TestFact.java` which will compile TestFact.java file. However, check the package name in `TestFact.java` file, which is `com.sid.myapp`, that means, even thought the path is `src/TestFact.java`, it will put the `TestFact.java` file in `com/sid/myapp/` directory inside `out/` directory due to the package name.
However, after compilation `./run.sh` cannot run the comiled `.class` file as it will try to run `TestFact` directly (mapped from `src/TestFact.java`), but it should ideally have run `com.sid.myapp.TestFact`.

In order to execute the java file, first compile using `javac -cp "out/:lib/*" src/TestFact.java` and then run using `java -cp 'out/' com.sid.myapp.TestFact`

# How to run tests

First use the below command to give executable access to test.sh file:

`chmod +x test.sh `

Then run the below command:

`./test.sh`

# Let's understand what's happening in test.sh file:

1. First we're deleting any pre-compiled files in `out/` directory using `rm -rf out/*`
2. Then compiling every `.java` file in `src/` directory to `out/` using: "javac -d out/ -cp "src/:lib/*"  `find src -type f -name "*.java"`"
3. Then running the executables. the last echo part is basically finding any class file that ends with `*Test.class` suffix and then changing directory notacion to package notation. The rest of the part is pretty simple, we're directly running JUnitCore class and giving all the package notationed test class names as parameter. Remeber, along with junit jar, we need hamcrest-core jar as well as that's a dependency of junit.


To avoid all this complexity, use gradle or maven.

# How to create an executible jar for the project:

1. First run the below command to compile all java files from `src/` directory into `out/` directory.
    ```
    javac -d out/ -cp "src/:lib/*"  `find src -type f -name "*.java"`;
    ```

2. Then run `jar cfe Practice1.jar com.sid.myapp.TestFact -C out/ .` to create the jar named `Practice.jar`. In this command, `c` option means a creation, `f` is to give the file name of the created jar and `e` is to give the entrypoint, that is the main method containing class with package notation. `-C` means go the the directory and then copy all of it's content in the jar to destination directory, this command takes 2 parameters: source directory from file-system and destination directory inside jar.

3. Then run `java -jar Practice1.jar` command to run the jar.