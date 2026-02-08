BookStore/
├── BookStore.API/ (Backend)
│   ├── Controllers/
│   ├── Data/
│   ├── Dtos/
│   ├── Entities/
│   ├── Services/
│   ├── appsettings.json
│   └── Program.cs
└── bookstore-app/ (Frontend)
    ├── src/
    │   ├── app/
    │   │   ├── author-list/
    │   │   │   ├── author-list.component.ts
    │   │   │   ├── author-list.component.html
    │   │   │   └── author-list.component.css
    │   │   ├── book-list/
    │   │   │   ├── book-list.component.ts
    │   │   │   ├── book-list.component.html
    │   │   │   └── book-list.component.css
    │   │   ├── models/
    │   │   ├── services/
    │   │   ├── app.component.ts
    │   │   ├── app.component.html
    │   │   ├── app.component.css
    │   │   └── app.module.ts
    │   └── ...
    └── ...


dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.0
