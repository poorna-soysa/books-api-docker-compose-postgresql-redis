# Book API with .NET 8, Docker Compose, PostgreSQL, and Redis

This repository showcases a sample API built with .NET 8, designed to demonstrate the integration of Docker Compose for container orchestration. The application utilizes PostgreSQL as its primary database and Redis for caching, providing a robust foundation for scalable web Apis.

## Table of Contents

- [Getting Started](#getting-started)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Contributing](#contributing)
- [License](#license)
- [Support](#support)

## Getting Started

To get a local copy up and running, follow these simple steps.

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Docker

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/poorna-soysa/books-api-docker-compose-postgresql-redis.git
   ```
2. Navigate to the project directory
   ```sh
   cd books-api-docker-compose-postgresql-redis
   ```
3. Build and run the application:
   ```sh
   docker-compose up --build
   ```

## Architecture Overview

This template follows the Vertical Slice Architecture, which organizes code by features rather than technical concerns. Each feature is self-contained, promoting high cohesion and low coupling.

## Features

- **Built with .NET 8**: Utilizes the latest features for efficient development.
- **Docker Compose**: Manages multi-container applications seamlessly.
- **PostgreSQL**: Powerful relational database for data storage.
- **Redis**: Caching solution for improved performance.
- **Health Check**: Standardized approach for monitoring and assessing the operational status of systems.

## Technologies Used

- **.NET 8**
- **PostgreSQL**
- **Redis**
- **EF Core**

## Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Creat a Pull Request

## License

Distributed under the MIT License. See `LICENSE` for more information.

## Support

If you find this project helpful, consider buying me a coffee!

[![Buy Me a Coffee](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/poorna.soysa)
```
