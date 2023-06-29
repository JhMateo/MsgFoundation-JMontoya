CREATE DATABASE "MsgFoundation";

CREATE TABLE "Observations"
(
  "Id" uuid NOT NULL,
  "Fullname" TEXT NOT NULL,
  "Email" TEXT NOT NULL,
  "Phone" TEXT NOT NULL,
  "ObservationText" TEXT NOT NULL,
  "Date" timestamp with time zone NOT NULL,
  PRIMARY KEY ("Id")
);

CREATE TABLE "Users"
(
  "Id" uuid NOT NULL,
  "Username" TEXT NOT NULL,
  "FullName" TEXT NOT NULL,
  "Email" TEXT NOT NULL,
  "Password" TEXT NOT NULL,
  PRIMARY KEY ("Id")
);

CREATE TABLE "Credits"
(
  "Id" uuid NOT NULL,
  "IdUser" TEXT NOT NULL,
  "CreditValue" double precision NOT NULL,
  "Date" timestamp with time zone NOT NULL,
  "StatusCredit" TEXT NOT NULL,
  "Disbursed" TEXT NOT NULL,
  PRIMARY KEY ("Id")
);


CREATE TABLE "Motociclistas"
(
  "Cedula" TEXT NOT NULL,
  "FullName" TEXT NOT NULL,
  "Email" TEXT NOT NULL,
  "PlacaMoto" TEXT NOT NULL,
  "MarcaMoto" TEXT NOT NULL,
  "ModeloMoto" TEXT NOT NULL,
  PRIMARY KEY ("Cedula")
);

CREATE TABLE "Tecnomecanicas"
(
  "Id" uuid NOT NULL,
  "Cedula" TEXT NOT NULL,
  "PlacaMoto" TEXT NOT NULL,
  "FechaExp" timestamp with time zone NOT NULL,
  "FechaVen" timestamp with time zone NOT NULL,
  PRIMARY KEY ("Id")
);