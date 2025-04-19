# Welcome to BGHub!

The idea of this project was to offer a solution for my board game group to organise and manage our events. It also provided a great opportunity for me to practice my full-stack .NET skills.

**Hosted URL is currently not available - watch this space!**

In the meantime to view the project clone down the repos and run first the backend project to seed some data and spin up a local server, then run the frontend project.

---

## Backend

- Built with **ASP.NET Core**, following the **MVC model** with decoupled layers utilizing dependency injection.
- Uses **Entity Framework** as an ORM to map database tables to C# classes.
- Connected to an **In-Memory** database for testing purposes allowing anyone to demo the site with seeded data.
- Unit tests implemented using **NUnit** and **MOQ**, ensuring isolated testing of methods.

---

## Frontend

- Developed using **Blazor** as the frontend framework for a dynamic and interactive user experience.
- Utilizes **Razor components** for modular UI development.
- Communicates with the backend via **RESTful APIs**.

---

## Features

- **Event Management**: Users can view and manage events.
- **Game Collection**: Users can add games to their own collection from the BGG (BoardGameGeek) API.
- **Bring Games to Events**: The site will allow users to select which of their own games they wish to bring along to an event with warnings to indicate a duplicate game.

---

## Installation & Setup

### Prerequisites
- .NET SDK (latest version recommended)

### Clone the Repository
```sh
git clone https://github.com/RichardNeat/BGHub.git
cd BGHub
```

---

## Contact

For any inquiries or feedback, feel free to reach out via [LinkedIn](https://www.linkedin.com/in/richard-neat-24536766/).
