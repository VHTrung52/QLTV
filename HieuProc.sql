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


exec ThemDocGia  N'Trần Thị H', '2020-01-10', '1111111'