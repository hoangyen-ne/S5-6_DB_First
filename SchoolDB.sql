CREATE DATABASE SchoolDB;
GO

USE SchoolDB;
GO

CREATE TABLE Student (
    Id INT PRIMARY KEY IDENTITY(1,1), -- Khóa chính, tự động tăng
    Name NVARCHAR(50) NOT NULL,      -- Tên, không cho phép NULL
    Birth DATE NOT NULL,             -- Ngày sinh, không cho phép NULL
    Gender BIT NOT NULL,             -- Giới tính (0 hoặc 1), không cho phép NULL
    ImgUrl VARCHAR(MAX),             -- URL ảnh, cho phép NULL
    Mssv NCHAR(10) NOT NULL,         -- Mã số sinh viên, không cho phép NULL
    Description NVARCHAR(MAX)         -- Mô tả, cho phép NULL
);
select * from Student

set dateformat dmy
go

INSERT INTO Student VALUES (N'Nguyễn Văn A', '2002-05-10',   1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT2uLl8zBoK0_iM5pNwJAC8hQ2f68YKtlgc7Q&s', N'SV0010001', N'Sinh viên năm 3 ngành CNTT');

INSERT INTO Student VALUES (N'Trần Thị B',   '2003-08-22',   0,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT2uLl8zBoK0_iM5pNwJAC8hQ2f68YKtlgc7Q&s' , N'SV0010002', N'Yêu thích lập trình và thiết kế UI/UX');

INSERT INTO Student VALUES (N'Lê Văn C',     '2001-12-05',   1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT2uLl8zBoK0_iM5pNwJAC8hQ2f68YKtlgc7Q&s',N'SV0010003', N'Tham gia nhiều hoạt động ngoại khóa');

INSERT INTO Student VALUES (N'Phạm Thị D',  '2002-03-18',   0,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT2uLl8zBoK0_iM5pNwJAC8hQ2f68YKtlgc7Q&s',  N'SV0010004', NULL);

INSERT INTO Student VALUES (N'Hồ Văn E',     '2003-11-30',   1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT2uLl8zBoK0_iM5pNwJAC8hQ2f68YKtlgc7Q&s', N'SV0010005', N'Đang thực tập tại công ty phần mềm');
