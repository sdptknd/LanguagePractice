1. Core Commands

mvn clean

Purpose: Removes previous build artifacts (target directory) to ensure a fresh build.
Dependencies: None. This is typically the first step in a build cycle.
Internal Working: Deletes the target directory and its contents.


mvn compile

Purpose: Compiles the project's Java source code into bytecode (.class files).
Dependencies: May depend on mvn clean to start with a clean build environment.
Internal Working:
Uses the maven-compiler-plugin.
Compiles Java source files in src/main/java into bytecode.
Places the compiled bytecode in the target/classes directory.


mvn test

Purpose: Executes unit and integration tests.
Dependencies:
mvn compile: Requires the compiled classes from mvn compile to run the tests.
Internal Working:
Uses the maven-surefire-plugin for unit tests and the maven-failsafe-plugin for integration tests.
Runs tests in src/test/java and collects the results.


mvn package

Purpose: Creates a distributable package (JAR, WAR, etc.).
Dependencies:
mvn compile: Requires compiled classes.
mvn test: Often executed before packaging to ensure code quality.
Internal Working:
Uses the maven-jar-plugin, maven-war-plugin, or maven-assembly-plugin depending on the packaging type.
Creates a single archive file containing compiled classes, resources, and dependencies.


mvn install

Purpose: Installs the packaged artifact into the local Maven repository.
Dependencies:
mvn package: Requires a packaged artifact to install.
Internal Working:
Uses the maven-install-plugin.
Installs the artifact into ~/.m2/repository for use by other projects.


mvn deploy

Purpose: Deploys the packaged artifact to a remote repository.
Dependencies:
mvn install: Often used to install the artifact locally before deploying it to a remote location.
Internal Working:
Uses the maven-deploy-plugin.
Deploys the artifact to the configured remote repository.



2. Project Lifecycle and Reporting

mvn site

Purpose: Generates project documentation (Javadocs, reports) and publishes them.
Dependencies:
May depend on mvn compile: Some documentation (like Javadocs) requires compiled source code.
Internal Working:
Uses various plugins depending on the documentation to be generated (e.g., maven-javadoc-plugin, maven-jxr-plugin).
Generates reports and publishes them to a local or remote server.


mvn dependency:tree

Purpose: Displays the project's dependency tree.
Dependencies: None.
Internal Working:
Uses the maven-dependency-plugin.
Analyzes dependencies and displays a tree-like representation in the console.


mvn dependency:analyze

Purpose: Analyzes project dependencies for unused or test-only dependencies.
Dependencies: None.
Internal Working:
Uses the maven-dependency-plugin.
Analyzes dependencies and reports potential issues.


mvn help:describe

Purpose: Provides information about a specific plugin or goal.
Dependencies: None.
Internal Working:
Uses the maven-help-plugin.
Displays detailed information about the specified plugin or goal.


mvn help:effective-pom

Purpose: Displays the effective POM for the current project (merged from all parent POMs).
Dependencies: None.
Internal Working:
Uses the maven-help-plugin.
Merges the project's pom.xml with all parent POMs and displays the resulting effective POM.



3. Dependency Management

mvn versions:update

Purpose: Updates dependency versions to the latest available releases.
Dependencies: None.
Internal Working:
Uses the maven-versions-plugin.
Updates dependency versions in the pom.xml.


mvn dependency:resolve

Purpose: Resolves all project dependencies and their transitive dependencies.
Dependencies: None.
Internal Working:
Uses the maven-dependency-plugin.
Resolves all dependencies and downloads them to the local repository.



4. Release Management

mvn release:prepare

Purpose: Prepares for a project release by tagging the code and updating version numbers.
Dependencies:
May depend on mvn clean and mvn install as pre-release steps.
Internal Working:
Uses the maven-release-plugin.
Tags the current code in version control, updates version numbers in the pom.xml, and commits the changes.


mvn release:perform

Purpose: Performs the actual release by deploying the artifact to the remote repository.
Dependencies:
mvn release:prepare: Must be executed first to prepare the release.
Internal Working:
Uses the maven-release-plugin.
Deploys the released artifact to the configured remote repository.



5. Project Creation

mvn archetype:generate
Purpose: Creates a new Maven project from an archetype (project template).
Dependencies: None.
Internal Working:
Uses the maven-archetype-plugin.
Creates a new project directory and generates the necessary files based on the selected archetype.



6. Other Useful Commands

mvn clean install: Cleans the project and then installs the packaged artifact.
mvn clean package: Cleans the project and then creates the distributable package.
mvn -DskipTests: Skips running tests during the build.
mvn -Dmaven.test.skip=true: Skips running tests during the build (alternative syntax).




Key Dependency Relationships:

Build-related: clean -> compile -> test -> package -> install
Release-related: clean -> install -> release:prepare -> release:perform
Documentation: compile (optional) -> site