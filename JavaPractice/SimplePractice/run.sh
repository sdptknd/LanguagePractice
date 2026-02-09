rm -rf out/*;
args=(...$@);
# javac -d out/ -cp "out/:lib/*" $1 && java -cp "out/:lib/*" `echo $1 | sed -E 's/src\///g' | sed -E 's/\.java//g' | sed -E 's/\//./g'` ${args[@]:1};


(find . -name "*.java" | xargs -I {} javac -d out/ -cp "out/:lib/*" {}) && java -cp "out/:lib/*" `echo $1 | sed -E 's/src\///g' | sed -E 's/\.java//g' | sed -E 's/\//./g'` ${args[@]:1};