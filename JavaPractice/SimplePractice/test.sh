rm -rf out/*;
javac -d out/ -cp "src/:lib/*"  `find src -type f -name "*.java"`; 
java -cp "out/:lib/*" org.junit.runner.JUnitCore `echo \`find out -type f -name "*Test.class"\` | sed -E 's/out\///g' | sed -E 's/\.class//g' | sed -E 's/\//\./g'`