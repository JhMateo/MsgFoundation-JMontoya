# MsgFoundation-JMontoya
This project aims to use Service Tasks in Camunda by having the Camunda API integrated into .NET.

It allows to save in the database the information of the motorcyclists and the technomechanics of the Camunda JMontoya project.

## Introduction

This is the repository of the case project "MSG Foundation - JMontoya" used for academic purposes. This is a abstraction of the repository [MsgFoundation](https://github.com/RogerRoldan/MsgFoundation-Camunda-with-.Net-).

### What does this repository contain? 

This repository contains the source, in .NET of several functions required to be used for the execution of the APP. This case is used for working with Camunda Platform 7 (a BPM Engine) in business process execution.  

The code published in the folder "APP" is for being used locally on a pc. 

## ¿How to use this code? 

Using this repository involves: 

1. Installing a [PostgreSQL](https://www.postgresql.org/) instance, with PgAdmin. 
2. Cloning this repository. 
3. Running the Camunda Engine.
4. Creating the MSG Foundation database. 
5. Deploying this repo on .NET (it requires the previous items)

## Detailed step-by-step. 

### 1. Installing a [PostgreSQL](https://www.postgresql.org/) instance, with PgAdmin. 

Go to the [PostgeSQL download page](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads) and use your appropriate operating system package. 

Install all the features. Necessary to include the Builder. 

Use the password you want, but remember it (you will need it to set the access in the code). 

### 2. Using locally this repository.

Clone or download this repo. Remember to go to the Code button to obtain the link for Git Clone.  

### 3. Running the Camunda Engine. 

Go to your local folder of the Camunda Engine and execute the start.bat file. 

### 4. Creating of MSG Foundation database. 

With the SQL in the "DataBase" folder you can create the database in PgAdmin, remember that after creating the database you must enter it to create the tables.

You can also try: Copy the link where the .NET project was deployed (in my case http://localhost:5152) and on the internet browser add the string "/dbconexion" and press ENTER. 

### 5. Deploying this repo on .NET (it requires the previous item)

Open the folder of the repo with Visual Studio/Code, and edit the file "appsettings.json" with your password of the user postgres in PgAdmin. Now open a Terminal (Terminal -> New Terminal), and execute dotNet run if you use VS Code or just run it in VS. 

