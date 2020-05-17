create proc XemTatCaDocGia
as
begin
	select * from DOCGIA
end
go

-------------------------------------------------------------------------------------
create proc XemPhieuMuonCuaDG(@maDG int)
as
begin
	select * from PHIEUMUON where MaDocGia = @maDG
end
go

-------------------------------------------------------------------------------------
create proc XemChiTietPhieuMuon(@maPhieu int)
as
begin
	select * from CHITIETPHIEUMUON where MaPhieuMuon = @maPhieu
end
go

-------------------------------------------------------------------------------------
create proc ThemDocGia(@HoTen nvarchar(50), @NgaySinh datetime, @CMND nchar(20), @SDT nchar(20))
as
begin
	declare @x int
	set @x = (select CAST((select MAX(MaDocGia) from DOCGIA as MaDG) as int))

	insert into DOCGIA(MaDocGia, HoTen, NgaySinh, CMND, SoDienThoai) 
	values(@x+1, @HoTen, @NgaySinh, @CMND, @SDT)
end
go

-------------------------------------------------------------------------------------
create proc XemChiTietDG(@maDG int)
as
begin
	select * from DOCGIA where MaDocGia = @maDG
end
go

-------------------------------------------------------------------------------------
create proc SuaDocGia( @MaDG int, @HoTen nvarchar(50), @NgaySinh datetime, @CMND nchar(20), @SDT nchar(20))
as
begin
	UPDATE DOCGIA
	SET HoTen = @HoTen, NgaySinh = @NgaySinh, CMND = @CMND, SoDienThoai = @SDT
	WHERE MaDocGia = @MaDG;
end
go

-------------------------------------------------------------------------------------
Select * from DOCGIA where HoTen like N'%Tr%' and CMND like '%123%' and SoDienThoai like '%09%'

-------------------------------------------------------------------------------------
create proc ThemPhieuMuon(@MaNV int, @MaDG int ,@ThoiGian int, @NgayMuon datetime, @NgayTra datetime, @ThanhTien money)
as
begin
	declare @x int
	set @x = (select CAST((select MAX(MaPhieuMuon) from PHIEUMUON as MaPM) as int))

	insert into PHIEUMUON(MaPhieuMuon, MaNhanVien, MaDocGia, ThoiGian, NgayMuon, NgayTra, ThanhTien) 
	values(@x+1, @MaNV, @MaDG, @ThoiGian, @NgayMuon, @NgayTra, @ThanhTien)
end
go

-------------------------------------------------------------------------------------
create proc XemChiTietPhieuMuon(@maPM int)
as
begin
	select * from PHIEUMUON where MaDocGia = @maPM
end
go

-------------------------------------------------------------------------------------
create proc SuaPhieuMuon(@MaPhieuMuon int ,@ThoiGian int, @NgayMuon datetime, @NgayTra datetime)
as
begin
	UPDATE 
	SET ThoiGian = @ThoiGian, NgayMuon = @NgayMuon, NgayTra = @NgayTra
	WHERE MaPhieuMuon = @MaPhieuMuon
end
go
------------------------------
create proc XemTatCaDauSach
as
begin
	select * from DAUSACH
end
go
--------------------------------
create proc XemTacGia(@MaSach int)
as
begin
	select TenTacGia from TACGIA where MaTacGia in (select MaTacGia from DS_TACGIA where MaDauSach = @MaSach)
end
go
-----------------------------------------
create proc XemTheLoai(@MaSach int)
as
begin
	select TenTheLoai from THELOAI where MaTheLoai in (select MaTheLoai from DS_THELOAI where MaDauSach = @MaSach)
end
go
--------------------------------------
create proc XemNhaXuatBan(@MaSach int)
as
begin
	select TenNhaXuatBan from NHAXUATBAN where MaNhaXuatBan in (select MaNhaXuatBan from DS_NHAXUATBAN where MaDauSach = @MaSach)
end
go
------------------------------------------------
create proc XemTatCaDauSachTacGia(@tenTacGia nvarchar(50))
as
begin
	select * from DAUSACH where MaDauSach in (select MaDauSach from DS_TACGIA where MaTacGia = (select MaTacGia from TACGIA where TenTacGia like '%'+@tenTacGia +'%'))
end
go
-------------------------------------------------

create proc XemTatCaDauSachDauSach(@tenDauSach nvarchar(50))
as
begin
	select * from DAUSACH where TenDauSach like '%'+ @tenDauSach +'%'
end
go
-------------------------------------------------------
create proc XemTatCaDauSachTheLoai(@tenTheLoai nvarchar(50))
as
begin
	select * from DAUSACH where MaDauSach in (select MaDauSach from DS_THELOAI where MaTheLoai = (select MaTheLoai from THELOAI where TenTheLoai like '%'+ @tenTheLoai +'%'))
end
go
----------------------------------------------------------
create proc XemTatCaDauSachNXB(@tenNXB nvarchar(50))
as
begin
	select * from DAUSACH where MaDauSach in (select MaDauSach from DS_NHAXUATBAN where MaNhaXuatBan = (select MaNhaXuatBan from NHAXUATBAN where TenNhaXuatBan like '%'+@tenNXB +'%'))
end
go
--------------------------------------------------------
create proc XemTatCaDauSachKeSach(@keSach int)
as
begin
	select * from DAUSACH where MaKeSach = @keSach
end
go



XemTatCaDauSachTacGia N'Od'
select * from DAUSACH where MaDauSach in (select MaDauSach from DS_TACGIA where MaTacGia = (select MaTacGia from TACGIA where TenTacGia like '%'+N'Fujio' +'%'))
