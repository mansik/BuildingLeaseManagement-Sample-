﻿USE [master]
GO

CREATE DATABASE [BuildingLease]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BuildingLease', FILENAME = N'D:\DATA\BuildingLease.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BuildingLease_log', FILENAME = N'D:\DATA\BuildingLease_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
