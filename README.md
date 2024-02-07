# Real-Time Stock Exchange Application Documentation

## Overview

The Real-Time Stock Exchange Application is designed to provide users with live stock data and the ability to create orders. The application consists of a back-end ASP.NET Core Web API and a front-end Angular dashboard.

## Back-End API

The back-end API is responsible for handling stock-related functionalities. It interacts with the Alpha Vantage API to retrieve real-time stock data. Below are the endpoints available:

### Endpoint for retrieving real-time stock data:

- **Endpoint:** `/api/stocks?symbol={symbol}`
- **Method:** GET
- **Parameters:**
  - `symbol`: The stock symbol for which you want to retrieve data (e.g., AAPL for Apple Inc.).
- **Description:** This endpoint allows you to retrieve real-time stock data for a specific symbol. The response includes information such as stock symbols, current prices, and timestamps.

### Endpoint for retrieving historical stock data:

- **Endpoint:** `/api/stocks/{symbol}/history`
- **Method:** GET
- **Parameters:**
  - `symbol`: The stock symbol for which you want to retrieve historical data (e.g., AAPL for Apple Inc.).
- **Description:** This endpoint allows you to retrieve historical stock data for a specific symbol. The response includes historical data points for the given symbol.

### Endpoint for creating orders:

- **Endpoint:** `/api/stocks/order`
- **Method:** POST
- **Parameters (in the request body):**
  - `symbol`: The stock symbol for which the order is being created.
  - `orderType`: The type of the order (buy/sell).
  - `quantity`: The quantity of stocks in the order.
- **Description:** This endpoint allows you to create orders for buying or selling stocks. You need to provide the stock symbol, order type, and quantity in the request body.

## Front-End Angular Dashboard

The front-end Angular dashboard provides a user interface for viewing live stock data and creating orders. It communicates with the back-end API to retrieve data and perform actions. Below are the key features and components of the dashboard:

### Stocks List:

- **Description:** This component displays a list of stocks in real-time, including their symbols and current prices.

### Real-Time Stock Updates:

- **Description:** This feature ensures that the stock prices are updated in real-time, providing users with the latest information.

### Order Creation Form:

- **Description:** This component allows users to create orders for a selected stock. It includes fields for entering the stock symbol, order type (buy/sell), and quantity.

### Orders History:

- **Description:** This component displays the user's order history, including the order type, stock symbol, quantity, and timestamp.

## Integration with Alpha Vantage API

The Real-Time Stock Exchange Application integrates with the Alpha Vantage API to retrieve real-time and historical stock data. You need to sign up for an Alpha Vantage API key and configure it in the back-end API to enable data retrieval.

> **Note:** Make sure to handle authentication and authorization mechanisms to secure the API endpoints and protect user data.

## Setup Instructions

To run the ASP.NET Core Web API and Angular application, follow these steps:

1. **Set up the Development Environment:**
   - Install the .NET SDK: Visit the official [.NET website](https://dotnet.microsoft.com/) and download the latest .NET SDK for your operating system.
   - Install Node.js and npm: Visit the [Node.js website](https://nodejs.org/) and download the LTS version suitable for your operating system. This will also install npm (Node Package Manager).

2. **Clone the Project:**
   - Clone the repository containing the ASP.NET Core Web API and Angular application code from a version control system (e.g., GitHub) or obtain the code from another source.

3. **Set up the Backend (ASP.NET Core Web API):**
   - Open the project in your preferred Integrated Development Environment (IDE) such as Visual Studio or Visual Studio Code.
   - Make sure the required NuGet packages are restored. This can be done automatically by the IDE or by running the command `dotnet restore` in the project's root directory.
   - Modify the configuration files (e.g., `appsettings.json`) to include necessary settings such as the connection string to the database or API keys for external services.
   - Build the project using the IDE or by running the command `dotnet build` in the project's root directory.
   - Run the project using the IDE's debugging features or by executing the command `dotnet run` in the project's root directory. The API will start running on a specified port (e.g., localhost:5000).

4. **Set up the Frontend (Angular):**
   - Navigate to the Angular project directory within the cloned repository.
   - Install the required npm packages by running the command `npm install` in the project's root directory. This will download and install the necessary dependencies specified in the `package.json` file.
   - Modify the configuration files (e.g., `environment.ts) to include necessary settings such as the API endpoint URL.
   - Build the Angular project by running the command `ng build` in the project's root directory. This will compile the TypeScript code and generate the static assets in the `dist` folder.
   - Serve the Angular application locally by running the command `ng serve` in the project's root directory. The application will be accessible at `localhost:4200` by default.

5. **Access the Application:**
   - Open a web browser and navigate to `localhost:4200` to access the Angular dashboard. From there, you can interact with the application's features and functionalities that communicate with the ASP.NET Core Web API.

> **Note:** Make sure the ASP.NET Core Web API and Angular application are running simultaneously for proper communication between the frontend and backend.

These steps should help you get the ASP.NET Core Web API and Angular application up and running locally on your development machine.

Please let me know if you need any further assistance!
