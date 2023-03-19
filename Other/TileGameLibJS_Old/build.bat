cls
call clean.bat
@echo on
start "tsc" /wait cmd /c call tsc 
browserify "./js/TileGameLib.js" -o "./build/TileGameLib.js"
