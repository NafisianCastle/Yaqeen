# Yaqeen (یقین)

<br/>
<p align="center">
<a href="[https://github.com/NafisianCastle/Yaqeen](https://www.google.com/search?q=https://github.com/NafisianCastle/Yaqeen)"\>
<img src="[https://place-hold.it/80x80/673ab7/ffffff\&text=YQ](https://www.google.com/search?q=https://place-hold.it/80x80/673ab7/ffffff%26text%3DYQ)" alt="Logo" width="80" height="80"\>
</a>

<h3 align="center">Yaqeen: A Spiritual Habit Tracker</h3>

<p align="center">
A cross-platform mobile application designed to help Muslims build consistency and flow in their daily spiritual practices through a structured, gamified, and personalized experience.
<br/>
<br/>
<a href="[https://github.com/NafisianCastle/Yaqeen/issues](https://www.google.com/search?q=https://github.com/NafisianCastle/Yaqeen/issues)">Report Bug</a>
·
<a href="[https://github.com/NafisianCastle/Yaqeen/issues](https://www.google.com/search?q=https://github.com/NafisianCastle/Yaqeen/issues)">Request Feature</a>
</p>
</p>

-----

## About The Project

Yaqeen is a comprehensive spiritual companion for the modern Muslim. The app's core mission is to facilitate consistent engagement with daily religious practices, including prayers (salah), supplications (duas), and Quranic recitation, through a structured and motivating user experience.

It features a tiered content system, a sophisticated gamification engine, and deep personalization to help users at every stage of their spiritual journey, from beginner to advanced.

> **Disclaimer:** This project is an independent initiative and is not affiliated with the Yaqeen Institute for Islamic Research.

### Key Features

  * **Tiered To-Do Lists:** Preset daily tasks for Beginner, Intermediate, and Advanced levels, covering prayers, duas, and Quran recitation.
  * **Gamification Engine:** Earn points for completing tasks, track your progress, and unlock new levels to stay motivated.
  * **Rewards System:** Redeem points to unlock higher levels or for tangible, physical gifts delivered to your location.
  * **Personalization:** Customize your daily to-do plan to fit your personal spiritual goals.
  * **Analytics Dashboard:** Visualize your progress with insightful charts and statistics on your daily, weekly, and monthly consistency.
  * **Secure Backup:** Backup your progress and custom plans securely to your personal Google Drive.
  * **Modern Authentication:** Secure and easy login using Email/Password or Google Single Sign-On (SSO).

-----

## Built With

The application is built on a modern, unified.NET technology stack for robust performance and scalability.

  * **Backend:**
      * .NET 9
      * ASP.NET Core Web API
  * **Mobile App:**
      * .NET MAUI (Multi-platform App UI)
  * **Promotional Website:**
      * ASP.NET Core Razor Pages
  * **Database:**
      * PostgreSQL
      * Entity Framework Core
  * **Core Services:**
      * **Authentication:** ASP.NET Core Identity
      * **Push Notifications:** Azure Notification Hubs
      * **Cloud Backup:** Google Drive API

-----

## Getting Started

To get a local copy up and running, follow these simple steps.

### Prerequisites

  * **Visual Studio 2022** with the following workloads installed:
      * ASP.NET and web development
      * .NET Multi-platform App UI development
  * **.NET 9 SDK** (or the version specified in `global.json`)
  * **PostgreSQL** server installed and running.

### Installation

1.  **Clone the repository:**

    ```sh
    git clone https://github.com/NafisianCastle/Yaqeen.git
    
    ```

2.  **Configure Backend Secrets:**

      * Navigate to the backend API project (e.g., `Yaqeen.Api`).
      * Right-click the project and select "Manage User Secrets".
      * Add your PostgreSQL connection string and Google OAuth credentials:
        ```json
        {
          "ConnectionStrings": {
            "DefaultConnection": "Host=localhost;Port=5432;Database=yaqeen_db;Username=postgres;Password=your_password"
          },
          "Authentication:Google": {
            "ClientId": "YOUR_GOOGLE_CLIENT_ID",
            "ClientSecret": "YOUR_GOOGLE_CLIENT_SECRET"
          }
        }
        ```

3.  **Apply Database Migrations:**

      * Open the Package Manager Console in Visual Studio.
      * Ensure the API project is the default project.
      * Run the command to create and apply the database schema [1]:
        ```sh
        Update-Database
        ```

4.  **Run the Backend API:**

      * Set the `Yaqeen.Api` project as the startup project and run it. It will host the backend services on a local port (e.g., `https://localhost:7123`).

5.  **Configure and Run the Mobile App:**

      * Open the `Yaqeen.App` project.
      * Update the API endpoint in the app's configuration to point to your local backend URL.
      * Set the MAUI project as the startup project.
      * Select your target (Android Emulator, local Windows machine, etc.) and run the application.

-----

## Roadmap

Yaqeen is being developed in three strategic phases:

  * **Phase 1: MVP (Core Functionality)**

      * User Authentication (Email/Google)
      * Preset To-Do Lists & Task Completion
      * Basic Reminders & Points Accrual

  * **Phase 2: Expansion (Engagement & Personalization)**

      * Custom Task Management
      * Analytics Dashboard
      * Google Drive Backup/Restore
      * Virtual Rewards (Unlock Levels)
      * Badges & Streaks

  * **Phase 3: Maturity (Advanced Gamification & Growth)**

      * Physical Gift Redemption
      * Leaderboards (Friends & Global)
      * Content Expansion (e.g., Islamic Quizzes)
      * Admin Portal for Fulfillment

See the [open issues](https://www.google.com/search?q=https://github.com/NafisianCastle/Yaqeen/issues) for a full list of proposed features (and known issues).

-----

## Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".

1.  Fork the Project
2.  Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3.  Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4.  Push to the Branch (`git push origin feature/AmazingFeature`)
5.  Open a Pull Request

-----

## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

-----

## Contact

Your Name - [@your\_twitter](https://www.google.com/search?q=https://twitter.com/your_twitter) - email@example.com

Project Link: [https://github.com/NafisianCastle/Yaqeen](https://www.google.com/search?q=https://github.com/NafisianCastle/Yaqeen)

```
```
