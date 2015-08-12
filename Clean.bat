@echo off
title Cleaning...
echo Deleting packages...
rmdir /S /Q packages
echo Deleting bin
rmdir /S /Q Pikabu_BestComment\bin
echo Deleting obj
rmdir /S /Q Pikabu_BestComment\obj
echo Done!
