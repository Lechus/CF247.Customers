Customers WebAPI

Provides an interface to the CF247's customer data store.

## Overview

A simple Web Api that provides a ReST based interface into the CF247 customer data store. It is coded in C# and built using .NET Core 2.1.
There is a simple SQLExpress database that provides the 

## Endpoints

### GET /api/customers

Parameters : None

Response example
[
  {
    "customerId": "string",
    "firstName": "string",
    "lastName": "string",
    "emailAddress": "string",
    "password": "string"
  }
]

### GET api/customers/{customerid}

Parameters customerID string (uuid)

Response example
{
  "customerId": "string",
  "firstName": "string",
  "lastName": "string",
  "emailAddress": "string",
  "password": "string"
}

### POST api/customers

Parameters : Body

Request example
{
  "firstName": "string",
  "lastName": "string",
  "emailAddress": "string",
  "password": "string"
}

### PUT api/customers

Parameters : Body

Request example
{
  "firstName": "string",
  "lastName": "string",
  "emailAddress": "string",
  "password": "string"
}

## Get started

## Next Versions

1. Addition of Docker support
2. Authentication of user requests using JWT
3. Database to encrypt data to ensure data at rest is secure
4. Auditing capability to track data usage
5. PATCH method offerd as an alternative to PUT
