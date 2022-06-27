# Saving System
A simply saving system for each project. useful for saving every scriptable you want to save!

## Table of contents
* [General Info](#general-info)
* [Editor Info](#editor-info)
* [Setup](#setup)

## General Info

This repo is for the simplest use: with the [SavedData](https://github.com/fireBear-git/saving-system/blob/release/0.1/Assets/Saving%20System/Scripts/Scriptables/SavedData.cs) scriptable we loads wich Scriptables we want to save. The scriptables to be saved will be derive from the abstract scriptable [Salvable](https://github.com/fireBear-git/saving-system/blob/release/0.1/Assets/Saving%20System/Scripts/Scriptables/Savable.cs). 

When we didecide witch scriptable will be saved. Whe press the "Fill All Salvable" button from the instance of SavedData, the SavedData will be store all Salvable instance inside the project

## Editor Info

* Unity Version: 2021.3.0f1
* Universal Render Pipeline: 3D URP

## Setup

### Editor

Download latest .unitypackage version of this plugin. Drag n' drop inside every project you needed. Inside the project window create a new SavedData like the following image 

> TIP: It is recommended to have only one instance of SavedData within the project, avoiding the dispersion of data 

<p align="center"><img src="https://drive.google.com/uc?export=view&id=1Hbe7takyjyO9myjWd5V9CEkGZ25QMkEa"></p>

With the SavedData created we have some options: 

1. The Name of the file that will be saved;
2. A button that if pressed will find all the scriptables derived from th Salvable scriptable;
3. A button for clear the array of Savables;
4. A button for serialize the SavedData at editor time;
4. A button for overwrite all the scriptables from the loaded json at editor time;
5. Save the file with the serialized data;
6. Load the file with the serialized data;

The files will be stored into the [persisentDataPath](https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html) of Unity

<p align="center"><img src="https://drive.google.com/uc?export=view&id=1eOJDC0rLv5p_YbPGwYZBzHpgCC3qQq8U"></p>

### InGame

Added at the desidered GameObject the [SaveHolder](https://github.com/fireBear-git/saving-system/blob/release/0.1/Assets/Saving%20System/Scripts/Components/SaveHolder.cs) component. When Added, he automatically find the SavedData and cache him into the serialized field. With this component we can access to all methods of SavedData inside the code of game

<p align="center"><img src="https://drive.google.com/uc?export=view&id=1HHJwpNP4qKXf48KHrM3y1OrYqKRFMYvY"></p>
