@echo off
if exist js (
    rmdir /s /q js
)
if exist build\tgl.js (
    del build\tgl.js
)