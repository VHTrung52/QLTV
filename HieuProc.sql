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
--create proc XemChiTietPhieuMuon(@maPhieu int)
--as
--begin
--	select * from CHITIETPHIEUMUON where MaPhieuMuon = @maPhieu
--end
--go

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
--create proc TimKiemTTPM(@keywords int)
--as
--begin
--	Select * from PHIEUMUON where MaDocGia like 1 and (MaPhieuMuon like 1 or MaNhanVien like 1)
--	Select SACH.* 
--	from CHITIETPHIEUMUON inner join SACH on CHITIETPHIEUMUON.MaSach = SACH.MaSach 
--	where MaPhieuMuon like 1 and Sach.MaSach like 6 
--end

-------------------------------------------------------------------------------------
create proc ThemPhieuMuon(@MaNV int, @MaDG int ,@ThoiGian int, @NgayMuon datetime )
as
begin
	declare @x int
	set @x = (select CAST((select MAX(MaPhieuMuon) from PHIEUMUON as MaPM) as int))

	insert into PHIEUMUON(MaPhieuMuon, MaNhanVien, MaDocGia, ThoiGian, NgayMuon ) 
	values(@x+1, @MaNV, @MaDG, @ThoiGian, @NgayMuon )
end
go


-------------------------------------------------------------------------------------
create proc SuaPhieuMuon(@MaPhieuMuon int, @MaNhanVien int, @MaDocGia int, @ThoiGian int, @NgayMuon datetime, @NgayTra datetime)
as
begin
	UPDATE PHIEUMUON
	SET MaNhanVien = @MaNhanVien, MaDocGia = @MaDocGia ,ThoiGian = @ThoiGian, NgayMuon = @NgayMuon, NgayTra = @NgayTra
	WHERE MaPhieuMuon = @MaPhieuMuon
end
go

-------------------------------------------------------------------------------------
create proc XemDSSachPhieuMuon(@maPM int)
as
begin
	select SACH.* 
	from CHITIETPHIEUMUON inner join SACH on CHITIETPHIEUMUON.MaSach = SACH.MaSach 
	where MaPhieuMuon = @maPM
end
go

-------------------------------------------------------------------------------------
create proc XemTatCaPhieuMuon 
as
begin
	select * from PHIEUMUON  
end
go

-------------------------------------------------------------------------------------
create proc XemChiTietPhieuMuon(@maPM int)
as
begin
	select * from PHIEUMUON where MaPhieuMuon = @maPM
end
go

-------------------------------------------------------------------------------------
create proc XoaSachTrongPhieuMuon( @maPhieuMuon int, @maSach int)
as
begin
	delete from CHITIETPHIEUMUON where MaSach = @maSach and MaPhieuMuon = @maPhieuMuon
end
go

-------------------------------------------------------------------------------------
--create proc TimKiemTTPM(@keywords nvarchar(100), @loaiTT nvarchar(30))
--as
--begin
--	select PHIEUMUON.*, 
--	case
--		when @loaiTT = 'Mã Phiếu Mượn' then ( 
--			select PHIEUMUON.* from PHIEUMUON join DOCGIA on PHIEUMUON.MaDocGia = DOCGIA.MaDocGia 
--			where @keywords like MaPhieuMuon
--			)
--		when @loaiTT = 'Mã Nhân Viên' then ( 
--			select PHIEUMUON.* from PHIEUMUON join DOCGIA on PHIEUMUON.MaDocGia = DOCGIA.MaDocGia 
--			where @keywords like MaNhanVien
--			)
--		when @loaiTT = 'Mã Độc Giả' then ( 
--			select PHIEUMUON.* from PHIEUMUON join DOCGIA on PHIEUMUON.MaDocGia = DOCGIA.MaDocGia 
--			where @keywords like PHIEUMUON.MaDocGia
--			)
--		when @loaiTT = 'Tên Độc Giả' then ( 
--			select PHIEUMUON.* from PHIEUMUON join DOCGIA on PHIEUMUON.MaDocGia = DOCGIA.MaDocGia 
--			where @keywords like HoTen
--			)
--		when @loaiTT = 'Ngày Mượn' then ( 
--			select PHIEUMUON.* from PHIEUMUON join DOCGIA on PHIEUMUON.MaDocGia = DOCGIA.MaDocGia 
--			where @keywords like NgayMuon
--			)
--		when @loaiTT = 'Ngày Trả' then ( 
--			select PHIEUMUON.* from PHIEUMUON join DOCGIA on PHIEUMUON.MaDocGia = DOCGIA.MaDocGia 
--			where @keywords like NgayTra
--			)
--	end
--	from PHIEUMUON join DOCGIA on PHIEUMUON.MaDocGia = DOCGIA.MaDocGia
--end


exec ThemDocGia  N'Trần Thị H', '2020-01-10', '1111111'
exec XemChiTietPhieuMuon 1
exec  XemTatCaPhieuMuon
exec XemPhieuMuonCuaDG 1
exec XemDSSachPhieuMuon 1
exec XemPhieuMuon 1
exec XoaSachTrongPhieuMuon 1, 56

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