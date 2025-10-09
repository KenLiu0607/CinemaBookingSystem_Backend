🎬 Cinema Booking System Backend (.NET 8 Web API)

這是一個以 .NET 8 Web API 為核心開發的後端系統，
提供電影場次、會員訂票與座位管理等 RESTful API，
可搭配前端（Vue 3 + Vite + Element Plus）組成完整的線上訂票平台。

🧩 專案簡介

Cinema Booking System 是一個模擬真實電影院運作的後端應用，
主要目標是學習並實踐：

RESTful API 設計

EF Core 資料存取層架構

前後端分離的專案設計模式

JWT 登入驗證與會員管理

🏗️ 系統架構
CinemaBookingBackend/
├── Controllers/ # 控制器層：API 入口
│ ├── MovieController.cs
│ ├── ShowtimeController.cs
│ ├── SeatController.cs
│ ├── BookingController.cs
│ └── MemberController.cs
│
├── Models/ # 實體模型（Entity）
│ ├── Movie.cs
│ ├── Hall.cs
│ ├── Seat.cs
│ ├── Showtime.cs
│ ├── Booking.cs
│ └── Member.cs
│
├── DTOs/ # 資料傳輸物件（Data Transfer Object）
│ ├── BookingDto.cs
│ └── MovieDto.cs
│
├── Services/ # 商業邏輯層
│ ├── IMovieService.cs
│ ├── IBookingService.cs
│ ├── MovieService.cs
│ └── BookingService.cs
│
├── Data/ # 資料庫設定與 DbContext
│ └── CinemaDbContext.cs
│
├── appsettings.json # 應用設定檔
└── Program.cs # 入口程式（註冊中介層與服務）

⚙️ 環境需求
項目 版本
.NET SDK 8.0+
IDE Visual Studio 2022 / VS Code
資料庫 PostgreSQL / SQL Server
ORM Entity Framework Core
API 測試工具 Swagger / Postman
🚀 專案執行方式
1️⃣ 複製專案
git clone https://github.com/kenliu/cinema-booking-backend.git
cd cinema-booking-backend

2️⃣ 建立環境設定（資料庫連線）

修改 appsettings.json：

{
"ConnectionStrings": {
"DefaultConnection": "Host=localhost;Database=Cinema;Username=postgres;Password=yourpassword"
}
}

3️⃣ 資料庫初始化
dotnet ef database update

4️⃣ 執行 API
dotnet run

5️⃣ 開啟 Swagger 測試介面

瀏覽器開啟 👉 https://localhost:7244/swagger

📡 API 範例
🎞️ 取得所有電影
GET /api/Movie

Response

[
{
"id": 1,
"title": "Inception",
"duration": 148,
"rating": "PG-13"
}
]

🎟️ 建立訂票紀錄
POST /api/Booking

Request

{
"memberId": 1,
"showtimeId": 3,
"seatIds": [15, 16],
"paymentMethod": "CreditCard"
}

Response

{
"bookingId": "a1f5b2c3-...",
"status": "Success",
"totalPrice": 560
}

🔐 JWT 驗證（範例）

註冊會員：POST /api/Member/Register

登入會員：POST /api/Member/Login

登入成功後會取得 JWT Token，後續 API 呼叫需加上：

Authorization: Bearer <token>

🧠 專案重點

使用 Dependency Injection (DI) 管理服務

採用 Repository + Service Pattern

利用 EF Core 管理關聯模型（電影、場次、座位、會員）

具備跨域設定（CORS）供前端連線

提供 Swagger 文件以利測試與開發

📦 未來規劃

加入會員點數與折扣機制

支援信用卡付款模擬

整合外部電影資料 API

導入 Redis 快取提升效能

建立前端票券頁面與 QR Code 驗證

🧑‍💻 作者資訊

開發者： Ken Liu
角色： 系統工程師 / 專案開發者
技術棧：
.NET 8 Web API
Entity Framework Core
PostgreSQL / SQL Server
Vue 3 + Vite (前端)
Element Plus (UI)
