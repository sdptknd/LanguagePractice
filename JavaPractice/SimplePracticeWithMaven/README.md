This is the root directory, run any command from this directory.

https://www.youtube.com/watch?v=Xatr8AZLOsE&ab_channel=MarcoCodes


1. Install maven in system using `brew install maven`. systemwise maven installation is only required to initiate maven project or to  create maven wrapper files in the repository.

2. If maven wrapper is not present in repository, then run `mvn wrapper:wrapper` to create maven wrapper in the repository. Then 2 files will be created mvnw (for mac/linux) and mvnw.cmd (for windows command prompt). after this, we can use the repository maven wrapper instead of the system wise installed maven (thought both can be usable). so let's run `./mvnw -v` to check if the wrapper is working. [Don't worry about .mvn directory, it's autogenarated and I don't know what it does]

3. Every valid maven project needs a `pom.xml` file at route which is the config file for maven to work. You can create it manually or create a new maven project in intellij idea which will auto create a pom file or initiate a maven project with `mvn archetype:generate` command. You keep adding dependencies to your project in maven which will update the `pom.xml` file. My initial `pom.xml` file was created using intelllij idea approach which is kept at `pom_initial.xml` file.

4. now let's run `./mvnw validate` to check if it's a valid maven project. basically it checks for a valid `pom.xml` file and some more thing.

5. There'll be a dependencies section, where we can see and add our dependency libraries (see `pom.xml`). To add a dependency find the dependency tag for the library from google search or by looking at official maven repo at https://search.maven.org/ or https://central.sonatype.com/ and add it in the dependencies section in `pom.xml` file. A dependency can also have a scope, that means when the dependency is required. For example scope value test means that the dependency is only required while running tests; for example junit dependency. (a dependency can be added directly in intellij, go to dependency senciton, press enter and then cmd+n for code generation and then go to dependency option)

6. Maven keep all compiled classes and other artifacts in `target/` directory at root, it will create a directory if not present.

7. Please try autogenaration using ide, like writing tests and all.

8. Check [this file](./mavenCommands.md) for details about different maven commands.

9. We can also add plugins to maven to support more commands. For example, I've added `exec-maven-plugin`, that helps to run the main method containing class (`Important` for my case). (Yes, plugin config also looks similar to dependency config). Now I can run `./mvnw compile exec:java` command to run the app (basically run `Important` compiled class). `exec:java` part comes from the plugin. And look at the command, I've mentioned multiple commands after `./mvnw`. this is doable and should be done in my case as `compile` step is required before running the app using `exec:java`.

## Create a Maven project from scratch:

Either use intellij idea to create a new project or use `mvn archetype:generate` and provide values like groupId=com.example, artifactId=madProject etc. this will create a new directory for the project.

## Maven's convensional folder structure:

```
my-java-project/
├── pom.xml 
├── src/   <-- all code goes here
│   ├── main/    <-- all source code goes here
│   │   ├── java/  <-- language (there're multiple jvm based langualges)
│   │   │   └── com/ <-- package naming starts here
│   │   │       └── example/ 
│   │   │           └── MyMainClass.java 
│   │   ├── resources/ <-- resources for the app like images or configs etc.
│   │       └── application.properties 
│   ├── test/ <-- tests goes here
│       ├── java/ <-- langualge
│       │   └── com/ <-- package naming starts here and usually follows the saem in `main`
│       │       └── example/ 
│       │           └── MyTest.java
│       ├── resources/  <-- keep test resources like test data
```


NOTE: We can have multi module maven project. Each module would be a directory in root directory of the project. Each module will have their `pom.xml` file. However, there'll be a parent `pom.xml` at root. this is useful to handle big projects. read about it.


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

1. Firstly you can run `./mvnw clean compile package` to create a JAR file. This will create a JAR file in `target/` directory. However, this JAR is not executable, because as we know, an executable JAR needs Main class path in it''s MANIFEST. that's the next step.

2. Add the below plugin config to `pom.xml` file to create an executable JAR. 
    ```
    <plugin>
        <groupId>org.apache.maven.plugins</groupId>
        <artifactId>maven-jar-plugin</artifactId>
        <version>3.1.0</version>
        <configuration>
          <archive>
            <manifest>
              <addClasspath>true</addClasspath>
              <mainClass>com.sid.myapp.Important</mainClass>
            </manifest>
          </archive>
        </configuration>
      </plugin>
    ```

    In this plugin config, we're explicitly mentioning the mainClass and also asking the plugin to addClasspath to the JAR file. Now run `./mvnw clean compile package` to create a jar under `target/` directory. However, even though this new one is executable, it will throw error because the created jar only contains your code, not dependencies. Let's handle it in next step.

    (however running `java -cp "/Users/sudiptakundu/.m2/repository/org/apache/commons/commons-lang3/3.8.1/commons-lang3-3.8.1.jar:target/untitled1-1.0-SNAPSHOT.jar" com.sid.myapp.Impor
tant` will work because here we're mentioning the dependencies and the mainClass explicitly)

3. To include all dependencies and create a self-containing jar, we need another plugin. Add the below plugin config:

    ```
    <plugin>
        <groupId>org.apache.maven.plugins</groupId>
        <artifactId>maven-shade-plugin</artifactId>
        <version>3.2.1</version>
        <executions>
          <execution>
            <phase>package</phase>
            <goals>
              <goal>shade</goal>
            </goals>
          </execution>
        </executions>
        <configuration>
          <transformers>
            <transformer implementation="org.apache.maven.plugins.shade.resource.ManifestResourceTransformer">
              <mainClass>com.sid.myapp.Important</mainClass> 
            </transformer>
          </transformers>
        </configuration>
      </plugin>
    ```

    Here we're adding maven-shade-plugin, configuring the mainClass. Now we can run `./mvnw clean compile package` to create the jar in target directory, and then run `java -jar target/untitled1-1.0-SNAPSHOT.jar` command to run your app. (NOTE, there'll be 2 JARs in target directory, the one starts with `original...` is the basic jar only having the code.)