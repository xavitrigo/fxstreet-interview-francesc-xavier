# Interview Template (Football API)

## Introduction

This page was created to give general instructions to complete the Interview Test for FXStreet. 

## Football API :soccer:

The aim of this API is to store information about players, managers, referees, matches and league information. Each controller has 4 actions:

* GET
* POST
* PUT
* DELETE

GOALS:

# Fix current errors in the API
# Apply good practices in the project following clean code and DDD practices
# Take into account that we will probably switch repository type to other technology like MongoDB
# Implement Statistics controller following Clean Clode practices
# Create a Job that notifies 5 minutes before that a game is about to start
# Create a Job that notifies incorrect alignments sending a list of ids
# Create the frontend with a List of statistics (no Razor allowed, no new endpoints

## Instructions


1. Go to [this link](http://interview-api.azurewebsites.net/swagger/index.html) where we have placed the basic interface for the service. IMPORTANT! These are just the contracts, the API provided does not work.
2. The aim of the test is to replicate the interface with a full functional Web API.
3. The Web API must persist the data in whatever database you feel comfortable. (In case you want to use Azure contact javier@fxstreet.com to get the credentials).
4. The service should be available via a public URL. (In case you want to use Azure contact javier@fxstreet.com to get the credentials).
5. The code must be available in Github.
6. Once you have finished the exercise send an Email (javier@fxstreet.com) following the Email Template described bellow.

## Rules

1. The code must be in .net Core.
2. The code must be available in GitHub.
3. The Web API must be public.
4. The final result must be available in less than 10 days since the first interview.

## Coding Tips

1. The controller IncorrectAlignment is the endpoint that you need to consume for the GOAL 2 of the exercise.
2. As department we strongly believe in Clean Code and SOLID Principles :heart_eyes:, show us that you too.
3. We want to see your testing capabilities, despite is a CRUD web app, the second goal gives some room for it.
4. If you feel comfortable you can use some DevOps tool (Azure Devops, jenkins, etc..) to deploy the Web API but is not compulsive.
5. IMPORTANT :running: In case you didn't have the time to include certain capability/feature/technology comment them on the email and we will discuss it later on the interview.

## Email Template

Subject: FXStreet Interview - [Your full name]

Body: 

* Github Url
* API Url 
* Persistence Technology + Screenshot of the model
* Comments
