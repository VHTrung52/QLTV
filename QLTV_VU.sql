go
create proc PROC_GetTenTacGia(@maDauSach int)as
begin
	select TenTacGia
	from DAUSACH , DS_TACGIA , TACGIA
	where DAUSACH.MaDauSach=DS_TACGIA.MaDauSach and DS_TACGIA.MaTacGia =TACGIA.MaTacGia
	and DAUSACH.MaDauSach = @maDauSach
end


go
create proc PROC_GetTenNhaXuatBan(@maDauSach int)as
begin
	select TenNhaXuatBan
	from DAUSACH , DS_NHAXUATBAN , NHAXUATBAN
	where DAUSACH.MaDauSach=DS_NHAXUATBAN.MaDauSach and DS_NHAXUATBAN.MaNhaXuatBan =NHAXUATBAN.MaNhaXuatBan
	and DAUSACH.MaDauSach = @maDauSach
end


go
create proc PROC_GetTheLoai(@maDauSach int)as
begin
	select TenTheLoai
	from DAUSACH , DS_THELOAI , THELOAI
	where DAUSACH.MaDauSach=DS_THELOAI.MaDauSach and DS_THELOAI.MaTheLoai = THELOAI.MaTheLoai
	and DAUSACH.MaDauSach = @maDauSach
end

go
create proc PROC_GetSachThuocDauSach(@maDauSach int)as
begin
	select MaSach , TenSach,TinhTrang
	from SACH
	where MaDauSach=@maDauSach
end


go
create proc PROC_GetDauSachTheoMaDauSach(@maDauSach int)as
begin
	select *
	from DAUSACH
	where MaDauSach=@maDauSach
end


go
create proc PROC_TimKiemDauSachTheoTacGia(@tenTacgia nvarchar(50))as
begin
	select DAUSACH.MaDauSach , TenDauSach, MaKeSach, SoLuongHienTai, TongSo
	from DAUSACH , DS_TACGIA , TACGIA
	where DAUSACH.MaDauSach = DS_TACGIA.MaDauSach and DS_TACGIA.MaTacGia = TACGIA.MaTacGia
	and TenTacGia Like @tenTacgia
end

go
create proc PROC_TimKiemDauSachTheoDauSach(@tenDauSach nvarchar(50))as
begin
	select *
	from DAUSACH 
	where TenDauSach Like @tenDauSach
end


go
create proc PROC_TimKiemDauSachTheoTheLoai(@tenTheLoai nvarchar(50))as
begin
	select DAUSACH.MaDauSach , TenDauSach, MaKeSach, SoLuongHienTai, TongSo
	from DAUSACH , DS_THELOAI , THELOAI
	where DAUSACH.MaDauSach = DS_THELOAI.MaDauSach and DS_THELOAI.MaTheLoai = THELOAI.MaTheLoai
	and TenTheLoai Like @tenTheLoai
end




--go
--alter proc PROC_TimKiemDauSachTheo2TheLoai(@tenTheLoai1 nvarchar(50) ,@tenTheLoai2 nvarchar(50))as
--begin
--	select DAUSACH.MaDauSach , DAUSACH.TenDauSach, DAUSACH.MaKeSach, DAUSACH.SoLuongHienTai, DAUSACH.TongSo
--	from DAUSACH , DS_THELOAI , THELOAI
--	where DAUSACH.MaDauSach = DS_THELOAI.MaDauSach and DS_THELOAI.MaTheLoai = THELOAI.MaTheLoai
--	and TenTheLoai Like N'%Hành Động%' and exists (
--					select DAUSACH.MaDauSach , DAUSACH.TenDauSach, DAUSACH.MaKeSach, DAUSACH.SoLuongHienTai, DAUSACH.TongSo
--					from DAUSACH , DS_THELOAI , THELOAI
--					where DAUSACH.MaDauSach = DS_THELOAI.MaDauSach and DS_THELOAI.MaTheLoai = THELOAI.MaTheLoai
--					and TenTheLoai Like N'%Hài Hước%')

--end


--	select DAUSACH.MaDauSach , DAUSACH.TenDauSach, DAUSACH.MaKeSach, DAUSACH.SoLuongHienTai, DAUSACH.TongSo
--	from DAUSACH , DS_THELOAI , THELOAI,(
--		select DS_THELOAI.MaDauSach
--		where DAUSACH.MaDauSach = DS_THELOAI.MaDauSach and DS_THELOAI.MaTheLoai = THELOAI.MaTheLoai
--		and TenTheLoai Like N'%Phiêu Lưu%'
--	) A
--	where DAUSACH.MaDauSach = DS_THELOAI.MaDauSach and DS_THELOAI.MaTheLoai = THELOAI.MaTheLoai
--	and TenTheLoai Like N'%Hành Động%'
	





go
create proc PROC_TimKiemDauSachTheoNhaXuatBan(@tenNhaXuatBan nvarchar(50))as
begin
	select DAUSACH.MaDauSach , TenDauSach, MaKeSach, SoLuongHienTai, TongSo
	from DAUSACH , DS_NHAXUATBAN , NHAXUATBAN
	where DAUSACH.MaDauSach = DS_NHAXUATBAN.MaDauSach and DS_NHAXUATBAN.MaNhaXuatBan = NHAXUATBAN.MaNhaXuatBan
	and TenNhaXuatBan Like @tenNhaXuatBan
end


go
create proc PROC_TimKiemDauSachTheoKeSach(@tenKeSach nvarchar(50))as
begin
	select DAUSACH.MaDauSach , TenDauSach, DAUSACH.MaKeSach, SoLuongHienTai, TongSo
	from DAUSACH ,KESACH
	where DAUSACH.MaDauSach = KESACH.MaKeSach
	and TenKeSach Like @tenKeSach
end



go
create proc PROC_ThemTacGiaChoDauSach(@maDauSach int , @maTacGia int)as
begin
	insert into DS_TACGIA
	values(@maDauSach,@maTacGia)
end



go
create proc PROC_XoaTacGiaChoDauSach(@maDauSach int , @tenTacGia nvarchar(50))as
begin
	delete DS_TACGIA
	where MaDauSach= @maDauSach and MaTacGia in (select MaTacGia 
						from TACGIA 
						where TenTacGia= @tenTacGia)
end


go
create proc PROC_ThemTheLoaiChoDauSach(@maDauSach int , @maTheLoai int)as
begin
	insert into DS_THELOAI
	values(@maDauSach,@maTheLoai)
end


go
create proc PROC_XoaTheLoaiChoDauSach(@maDauSach int , @tenTheLoai nvarchar(50))as
begin
	delete DS_THELOAI
	where MaDauSach= @maDauSach and MaTheLoai in (select MaTheLoai 
						from THELOAI 
						where TenTheLoai= @tenTheLoai)
end



go
create proc PROC_ThemNhaXuatBanChoDauSach(@maDauSach int , @maNhaXuatBan int)as
begin
	insert into DS_NHAXUATBAN
	values(@maDauSach,@maNhaXuatBan)
end

go
create proc PROC_XoaNhaXuatBanChoDauSach(@maDauSach int , @tenNhaXuatBan nvarchar(50))as
begin
	delete DS_NHAXUATBAN
	where MaDauSach= @maDauSach and MaNhaXuatBan in (select MaNhaXuatBan 
						from NHAXUATBAN 
						where TenNhaXuatBan= @tenNhaXuatBan)
end


go
create proc PROC_ThemDauSach(@tenDauSach nvarchar(50),@maKeSach int ,@soLuongHienTai int ,@tongSo int )as
begin
	insert into DAUSACH(TenDauSach,MaKeSach,SoLuongHienTai,TongSo)
	values(@tenDauSach,@maKeSach,@soLuongHienTai,@tongSo)
end

go
create proc PROC_SuaDauSach(@maDauSach int, @tenDauSach nvarchar(50),@maKeSach int ,@soLuongHienTai int ,@tongSo int )as
begin
	update DAUSACH
	set TenDauSach = @tenDauSach , MaKeSach =@maKeSach, SoLuongHienTai=@soLuongHienTai,TongSo=@tongSo
	where MaDauSach = @maDauSach
end

go
create proc XemTatCaDauSachTacGia(@tenTacGia nvarchar(50))
as
begin
    select * from DAUSACH where MaDauSach in (select MaDauSach from DS_TACGIA where MaTacGia = (select MaTacGia from TACGIA where TenTacGia like '%'+@tenTacGia +'%'))
end
go



create proc PROC_GetTatCaSach as
begin
	select * from SACH
end

go
create proc PROC_TimKiemSach(@tenSach nvarchar(50))as
begin
	select * 
	from SACH
	where TenSach like @tenSach
end

go
create proc PROC_ThemSach(@maDauSach int , @tenSach nvarchar(50) , @tinhTrang bit)as
begin
	declare @ma int 
	set @ma = (select top 1 MaSach from SACH order by MaSach desc)
	insert into SACH(MaSach,MaDauSach,TenSach,TinhTrang)
	values(@ma + 1,@maDauSach,@tenSach,@tinhTrang)
end



go
create proc PROC_SuaThongTinSach(@maSach int , @maDauSach int , @tenSach nvarchar(50) , @tinhTrang bit)as
begin
	update SACH
	set MaDauSach =@maDauSach ,TenSach=@tenSach,TinhTrang=@tinhTrang
	where MaSach=@maSach
end


go
create proc PROC_XoaSach(@maSach int)as
begin
	delete SACH
	where MaSach=@maSach
end

go 
create proc PROC_ThemDauSachChoSach(@maSach int , @maDauSach int )as
begin
	update SACH
	set MaDauSach = @maDauSach
	where MaSach = @maSach
end


go
create proc PROC_XoaDauSachChoSach(@maSach int )as
begin
	update SACH
	set MaDauSach = 1
	where MaSach = @maSach
end
create proc PROC_DauSach_Sach(@maDauSach int )as
begin
    select * from DAUSACH
    where MaDauSach=@maDauSach
end