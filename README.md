# MidTerm WindowProgramming  
# 🎨 Paint Application & 🎹 Slide Piano Game (WinForms)

Dự án bao gồm hai ứng dụng được xây dựng trên nền tảng **C# Windows Forms**, tập trung vào việc thiết kế giao diện người dùng (GUI), xử lý sự kiện và tương tác trực tiếp với người dùng thông qua các control như Button, Panel, Timer, ComboBox,...

---

## 🏗️ Kiến trúc Dự án (Architecture)

Dự án được tổ chức theo hướng module hóa, tách biệt các thành phần giao diện và logic xử lý để dễ quản lý và phát triển:

* **GUI (Forms):** Chứa các Form chính và các control giao diện
* **Core Logic:** Xử lý vẽ hình (Paint) và gameplay (Slide Piano)
* **Assets/Data:** Lưu trữ file âm thanh và dữ liệu note

PaintApplication
│ MainForm.cs
│ SettingsForm.cs
│ ShapeManager.cs
│ PenProperties.cs
│ BrushProperties.cs
│
SlidePiano
│ ChooseMap.cs
│ Form1.cs
│ ResultForm.cs
│
Assets
│ Audio files
│ Note data (.txt)


---

## ✨ Chức năng chính

## 🎨 Paint Application

### 🔹 Giao diện chính (MainForm)

* **Panel vẽ (Canvas):**
  * Khu vực chính để vẽ hình
  * Xử lý sự kiện:
    - `MouseDown`
    - `MouseMove`
    - `MouseUp`

* **Toolbar Buttons:**
  * Rectangle, Ellipse, Line, Arc
  * Mouse (Select mode)
  * Group / Ungroup

---

### 🔹 Các chức năng

1. **Vẽ hình**
   * Chọn shape → kéo chuột để vẽ
   * Quản lý bằng `ShapeManager`

2. **Di chuyển đối tượng**
   * Chọn chế độ Mouse
   * Click & drag để di chuyển shape

3. **Group / Ungroup**
   * Gom nhiều shape thành một
   * Tách shape ra

---

### 🔹 Settings (SettingsForm)

* Đổi màu:
  - Top Panel
  - Bottom Panel
  - Text

---

### 🔹 Thuộc tính vẽ

* **PenProperties**
  * Color
  * Width
  * DashStyle

* **BrushProperties**
  * Fill Color

---

## 🎹 Slide Piano Game

### 🔹 Menu Form (ChooseMap.cs)

* **ComboBox (`cbMusic`):**
  * Hiển thị danh sách bài nhạc

* **Buttons:**
  * `btnStart` → mở Game
  * `btnExit` → thoát

---

### 🔹 Game Form (Form1.cs)

* **Panel (`plGame`):**
  * Khu vực gameplay
  * Chia 4 lane

* **PictureBox (`pbHitLine`):**
  * Vạch tính điểm

* **Timer (`gameTimer`):**
  * Điều khiển game loop:
    - Spawn note
    - Di chuyển note
    - Check hit/miss

---

### 🔹 Gameplay

1. **Spawn Note**
   * Đọc từ file `.txt`

2. **Di chuyển**
   * Note rơi theo trục Y

3. **Input**
   * Nhấn phím tương ứng lane

4. **Tính điểm**
   * Score
   * Combo
   * Accuracy

---

### 🔹 Result Form

* Hiển thị:
  - Score
  - Accuracy
  - Combo

* Buttons:
  * `btnReplay`
  * `btnMenu`

---

## 🛠️ Công nghệ & Công cụ

* **Ngôn ngữ:** C# (.NET Framework)  
* **Framework:** Windows Forms  
* **IDE:** Visual Studio 2022  

---

## 🚀 Hướng dẫn chạy

1. Mở project bằng Visual Studio  
2. Chọn project cần chạy  
3. Nhấn `F5` để chạy  

---

## 👤 Thông tin Tác giả

* **Sinh viên thực hiện:**  
  - Tran Gia Kiet  
  - Mai Viet Thanh  

* **Giảng viên hướng dẫn:**  
  - PhD. Le Van Vinh  

* **Đơn vị:**  
  - HCMUTE  

---

## 📌 Trạng thái hiện tại

- ✅ Paint:
  - Hoàn thành vẽ shape  
  - Hoàn thành chỉnh màu  
  - Hoàn thành group / ungroup  

- ✅ Slide Piano:
  - Hoạt động gameplay cơ bản  
  - Có menu, game, result  
  - Có hệ thống tính điểm  

- 🔄 Có thể mở rộng thêm hiệu ứng và tối ưu UI  

---
