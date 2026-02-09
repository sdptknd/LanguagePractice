This is the root directory, run any command from this directory.

https://www.youtube.com/watch?v=gKPMKRnnbXU&ab_channel=MarcoCodes


1. Install gradle in system using `brew install gradle` or using sdkman or from gradle's official site or some other way. systemwise gradle installation is only required to initiate gradle project or to create gradle wrapper files in the repository.

2. If gradle wrapper is not present in repository, then run `gradle wrapper` to create maven wrapper in the repository. Then 2 files will be created gradlew (for mac/linux) and gradlew.bat (for windows command prompt). Also `.gradle/` and `gradle/` directories will be created. Ignore them for now. after this, we can use the repository gradle wrapper instead of the system wise installed gradle (thought both can be usable). so let's run `./gradlew -v` to check if the wrapper is working. 

3. Every valid gradle project needs a `build.gradle` file at route which is the config file for gradle to work. You can create it manually or create a new gradle project in intellij idea which will auto create a pom file or use can use `gradle init` command to initiate a gradle project inside an empty directory that will generate a basic `build.gradle` file. You keep adding dependencies to your project in gradle which will update the `build.gradle` file. My initial `build.gradle` file was created using `gradle init` which is kept at `build.gradle_initial` file.

4. There'll be a dependencies section, where we can see and add our dependency libraries (see `build.gradle`). To add a dependency find the dependency tag for the library from google search or by looking at official maven repo at https://search.maven.org/ or https://central.sonatype.com/ and add it in the dependencies section in `build.gradle` file. We need a key like `testImplementation` or `implementation` while adding a dependency, this defines the scope of the dependency. For example key `testImplementation` means that the dependency is only required while running tests; for example junit dependency. (a dependency can be added directly in intellij, go to dependency senciton, press enter and then cmd+n for code generation and then go to dependency option)

5. Maven keep all compiled classes and other artifacts in `build/` directory at root, it will create a directory if not present.

6. Please try autogenaration using ide, like writing tests and all.

8. Check [this file](./gradleCommands.md) for details about different maven commands.

9. We can also add plugins to maven to support more commands. For example, you can see `application`, that helps to run the main method containing class (`Important` for my case). We also need to mention the Main class with package notation in `mainClass` under application section. Using this plugin, I can run `./gradlew run` command to run the app (basically run `Important` compiled class). We also can have plugin versions.

10. Gradle also supports custom tasks and build script (in groovy or kotlin). For example, 'test' is a custom task in `build.gradle`

## Create a Gradle project from scratch:

Either use intellij idea to create a new project or use `gradle init` in an empty directory and provide required values.

## Gradle's convensional folder structure:

```
my-gradle-project/
├── build.gradle          # Main Gradle build script
├── settings.gradle       # Settings for multi-project builds (optional)
├── src/                 # Source code directory
│   ├── main/            # Main source code
│   │   ├── java/       # Java source files (e.g., com/example/MyClass.java)
│   │   └── resources/  # Resource files (e.g., properties files, configuration files)
│   └── test/            # Test source code
│       ├── java/       # Java test files (e.g., com/example/MyClassTest.java)
│       └── resources/  # Test resources
└── gradle/             # Custom Gradle scripts (optional)
    └── wrapper/        # Gradle wrapper files 
```


NOTE: We can have multi module gradle project. Each module would be a directory in root directory of the project. Each module will have their `build.gradle` file. However, there'll be a parent `settings.gradle` file at root. this is useful to handle big projects. read about it.


## How JAR files work:

1. Based on ZIP: At its core, a JAR file is essentially a ZIP file with some special additions.   
2. Manifest File: The key element is the META-INF/MANIFEST.MF file. This manifest file contains crucial information about the JAR, such as:
    1. Main Class: If the JAR is an executable application, it specifies the fully qualified name of the class containing the main() method.
    2. Class-Path: Specifies dependencies on other JAR files.   
    3. Version Information: Contains version numbers and other metadata about the JAR.
  
3. Class Files: The primary content of a JAR file consists of compiled Java class files (.class files) organized in a hierarchical directory structure (e.g., com/example/mypackage/).
4. Resources: JAR files can also include various resources like:
    * Images: Used in graphical user interfaces (GUIs).
    * Sounds: For audio-related applications.   
    * Configuration Files: Like properties files or XML files.
    * Text Files: For documentation or other purposes.

how it looks from inside?

```
my-application.jar
├── META-INF/
│   └── MANIFEST.MF 
├── com/
│   └── example/
│       └── MyMainClass.class
├── resources/
│   └── config.properties
└── images/
    └── logo.png
```

## How to create JAR in Maven:

1. Firstly you can run `./gradlew jar` to create a JAR file. (somehow  `./gradle build` also creates the JAR). This will create a JAR file in `build/libs/` directory. However, this JAR is not executable, because as we know, an executable JAR needs Main class path in it''s MANIFEST. that's the next step.

2. Add the below section to `build.gradle` file to create an executable JAR. 
    ```
    jar {
    manifest {
        attributes 'Main-Class': 'com.sid.myapp.Important' 
    }
}
    ```

    In this section, we're explicitly mentioning the mainClass for the jar. Now run `./gradlew jar` to create a jar under `build/libs/` directory. However, even though this new one is executable, it will throw error because the created jar only contains your code, not dependencies. Let's handle it in next step.

3. To include all dependencies and create a self-containing jar, we need another plugin. Add the below plugin:

    ```
    id 'com.github.johnrengelman.shadow' version '8.0.0'
    ```

    Here we're adding com.github.johnrengelman.shadow plugin which looks at mainclass and creates a self containing jar in `/build/libs/` that ends with `-all.jar` name. Run `./gradlew shadowJar` for the jar to be created. Now run `java -jar build/libs/SimplePracticeWithGradle-all.jar` to run your app. (NOTE, there'll be 2 JARs in build/libs/ directory, the one ends with `-all.jar` is the self containing jar and the other one is basic jar only having the code.)