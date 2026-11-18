# TransConnect: Logistics Management Console (C#)

[![tests](https://github.com/samichellia90-bit/transconnect-logistics-manager/actions/workflows/tests.yml/badge.svg)](https://github.com/samichellia90-bit/transconnect-logistics-manager/actions/workflows/tests.yml)

A console application that manages a fictional road-haulage company: customers, employees, orders, routes and driver reviews.
Third-year object-oriented programming project (2024), built around two data structures written from scratch: a weighted graph with Dijkstra's shortest path, and a generic n-ary tree for the company organisation chart.

Author: Sami Chellia.

## Features

| Module | Content |
|---|---|
| Customers | Create, edit, delete; list sorted by name, city or total amount purchased |
| Employees | Organisation chart stored as a generic tree (`Noeud<T>`); hire under a manager, dismiss, display the hierarchy |
| Orders | Create and edit a delivery: customer, driver, vehicle, origin, destination, date |
| Routes | Undirected weighted graph of cities; add cities and road distances |
| Statistics | Deliveries per driver, orders over a period, average order price, average customer account, orders of one customer |
| Reviews | Rate a driver and compute the average rating |

## Design

- **Shortest path.** `Graph` stores an adjacency list and runs Dijkstra's algorithm with a sorted set as priority queue. Unreachable destinations return `double.MaxValue`.
- **Pricing.** Travel time is the shortest distance divided by an average speed of 90 km/h. The price is the travel time multiplied by the driver's hourly rate (20 EUR plus 25 EUR per year of seniority).
- **Organisation chart.** `Noeud<T>` is a generic tree node with recursive search (`FindAll` with a predicate) and sorting (`Sort` with a comparison). `Organigramme` builds the hierarchy on top of it.
- **Domain model.** `Personne` is an abstract base class for `Salarie` and `Client`; vehicles implement the `IVehicule` interface.

The application starts with a sample data set (4 customers, 20 employees, 4 cities) held in memory. Nothing is written to disk.

## Project structure

```
├── src/TransConnect/
│   ├── Program.cs           menus and sample data
│   ├── Graph.cs             weighted graph, Dijkstra
│   ├── Noeud.cs             generic n-ary tree
│   ├── Organigramme.cs      organisation chart
│   ├── Commande.cs          order, price and travel-time computation
│   ├── Personne.cs, Salarie.cs, Client.cs, GestionClients.cs
│   ├── IVehicule.cs, Vehicule.cs
│   ├── Statistiques.cs
│   └── Review.cs
└── tests/TransConnect.Tests/  xUnit tests
```

Identifiers, menus and source comments are in French.

## Quickstart

Requires the [.NET SDK](https://dotnet.microsoft.com/download) 8.0 or later.

```bash
git clone https://github.com/samichellia90-bit/transconnect-logistics-manager.git
cd transconnect-logistics-manager
dotnet test                               # 4 tests
dotnet run --project src/TransConnect     # interactive menu
```

## License

MIT. See [LICENSE](LICENSE).
