# Interview Template (Football API)

## Introduction

This page was created to give general instructions to complete the Interview Test for FXStreet. 

## Football API :soccer:

The aim of this API is to store information about players, managers, referees, matches and league information. Each controller has 4 actions:

* GET
* POST
* PUT
* DELETE

## Goals

1. Fix current errors in the API
2. Apply good practices in the project following clean code, DDD practices and Restful best practices
4. Implement Statistics controller following Clean Clode practices
5. Create a Job that notifies 5 minutes before a game starts incorrect alignments
7. Create the frontend with a List of statistics (no Razor allowed, no new endpoints allowed)

## Instructions

1. Clone the repository and execute it, it should compile but once runned some errors might appear
2. Go to [this link](http://interview-api.azurewebsites.net/swagger/index.html) where we have placed the basic interface for the service. IMPORTANT! These are just the contracts, the API provided does not work.
3. Resolve every Goal 
4. The Web API must persist the data in whatever database you feel comfortable.
5. The code must be available in a Github repository.
6. Once you have finished the exercise send an Email (javier@fxstreet.com and alain@fxstreet.com) following the Email Template described bellow.

## Rules

1. The code must be in .net Core.
2. The code must be available in GitHub.
4. There is no time for completition, but bear in mind that interview process can be close at any time.

## Coding Tips

1. The controller IncorrectAlignment is the endpoint that you need to consume for the GOAL 6 of the exercise.
2. Take into account that we will probably switch repository type to other technology like MongoDB
3. As department we strongly believe in Clean Code and SOLID Principles :heart_eyes:, show us that you too.
4. We want to see your testing capabilities, despite is a CRUD web app, the 5,6 GOAL gives some room for it.
5. If you feel comfortable you can use some DevOps tool (Azure Devops, jenkins, etc..) to deploy the Web API but is not compulsive.
6. IMPORTANT :running: In case you didn't have the time to include certain capability/feature/technology comment them on the email and we will discuss it later on the interview.

## Email Template

Subject: FXStreet Interview - [Your full name]

Body: 

* Github Url
* Persistence Technology + Screenshot of the model
* Comments
