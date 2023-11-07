# Roulette

## Roulette Game API

This is a simple C# REST API based on a roulette game. 
## Table of Contents

- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [API Endpoints](#api-endpoints)



## Getting Started

### Prerequisites

Before getting started, make sure you have the following prerequisites installed:

- [.NET Core](https://dotnet.microsoft.com/download) - The API is built using .NET Core 6.
- [SQLite](https://www.sqlite.org/index.html) - The database used for this project.

### Installation

1. Clone the repository to your local machine:

   ```bash
   git clone https://github.com/Govern24/Roulette.git

 # Usage

To use the Roulette Game API, you can make HTTP requests to the provided endpoints. You can use tools like Postman or Swagger to test and interact with the API.

# API Endpoints

Here are the available API endpoints:

- `POST /api/roulette/placebet`: Place a bet in the game.
- `GET /api/roulette/spin`: Spin the roulette wheel to determine the winning number.
- `POST /api/roulette/payout`: Calculate the payout for a specific bet.
- `GET /api/roulette/spins`: Retrieve the history of previous spins.  

   
