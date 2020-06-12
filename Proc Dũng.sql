create proc GetDanhSachTacGia 
as
begin
	select * from TACGIA
end

go

create proc GetDanhSachDSTacGia @matg int
as 
begin
	select * from DAUSACH where MaDauSach in (select MaDauSach from DS_TACGIA where MaTacGia = @matg)
end

go

alter proc GetDanhSachDSTacGiafilter @matg int, @str nvarchar(50)
as
begin
	select * 
	from DAUSACH 
	where MaDauSach in (select MaDauSach from DS_TACGIA where MaTacGia = @matg )
    AND MaDauSach LIKE '%'+@str+'%' OR TenDauSach LIKE '%'+@str+'%'
end

go

create proc DelDauSach_TacGia @matg int, @mads int
as
begin
	delete from DS_TACGIA where MaDauSach = @mads and MaTacGia = @matg
end

go

alter proc GetDanhSachTacGiafilter @str nvarchar(50)
as
begin
	select * from TacGia where MaTacGia LIKE '%'+@str+'%' OR TenTacGia LIKE '%'+@str+'%'
end

go

create proc AddTacGia @tenTG nvarchar(50), @ns datetime
as
begin
	declare @ma int
	select @ma = (select MAX(MaTacGia) from TACGIA)
	insert into TacGia(MaTacGia,TenTacGia,NgaySinh)
	values(@ma,@tenTG,@ns)
end

go

create proc EditTacGia @matg int, @tenTG nvarchar(50), @ns datetime
as
begin
	update TACGIA
	Set TenTacGia = @tenTG, NgaySinh = @ns
	where MaTacGia = @matg
end 

go

create proc GetDanhSachNXB
as
begin
	select * from NHAXUATBAN
end

go

create proc GetDanhSachDSNXB @maNXB int
as
begin
	select * from DAUSACH where MaDauSach in (select MaDauSach from DS_NHAXUATBAN where MaNhaXuatBan = @maNXB)
end

go 

alter proc GetDanhSachDSNXBfilter @manxb int, @str nvarchar(50)
as
begin
	select * 
	from DAUSACH 
	where MaDauSach in (select MaDauSach from DS_NHAXUATBAN where MaNhaXuatBan = @manxb )
    AND MaDauSach LIKE '%'+@str+'%' OR TenDauSach LIKE '%'+@str+'%'
end

go

alter proc GetDanhSachNXBfilter @str nvarchar(50)
as
begin
	select * from NhaXuatBan where MaNhaXuatBan LIKE '%'+@str+'%' OR TenNhaXuatBan LIKE '%'+@str+'%'
end

go

create proc AddNXB @tennxb nvarchar(50)
as
begin
	declare @ma int
	select @ma = (select MAX(MaNhaXuatBan) from NhaXuatBan)
	insert into NhaXuatBan(MaNhaXuatBan,TenNhaXuatBan)
	values(@ma,@tennxb)
end

go 

create proc EditNXB @maNXB int, @tennxb nvarchar(50)
as
begin
	update NhaXuatBan
	set TenNhaXuatBan = @tennxb
	where MaNhaXuatBan = @maNXB
end

go

create proc GetDanhSachTheLoai
as
begin
	select * from TheLoai
end

go

create proc GetDanhSachDSTheLoai @matl int
as
begin
	select * 
	from DAUSACH 
	where MaDauSach in (select MaDauSach from DS_TheLoai where MaTheLoai = @matl)
end

go

alter proc GetDanhSachDSTheLoaifilter @matl int , @str nvarchar(50)
as
begin
	select * 
	from DAUSACH 
	where MaDauSach in (select MaDauSach from DS_TheLoai where MaTheLoai = @matl )
    AND MaDauSach LIKE '%'+@str+'%' OR TenDauSach LIKE '%'+@str+'%'
end

go

alter proc GetDanhSachTheLoaifilter @str nvarchar(50)
as
begin
	select * 
	from TheLoai 
	where MaTheLoai LIKE '%'+@str+'%' OR TenTheLoai LIKE '%'+@str+'%'
end

go 

create proc AddTheLoai @tentl nvarchar(50)
as
begin
	declare @ma int
	select @ma = (select MAX(MaTheLoai) from TheLoai)
	insert into TheLoai(MaTheLoai,TenTheLoai)
	values(@ma,@tentl)
end

go 

create proc EditTheLoai @matl int, @tentl nvarchar(50)
as
begin
	update TheLoai
	set TenTheLoai = @tentl
	where MaTheLoai = @matl
end

go

create proc DelDauSach_NXB @manxb int, @mads int
as
begin
	delete from DS_NHAXUATBAN where MaDauSach = @mads and MaNhaXuatBan = @manxb
end

go

create proc DelDauSach_THELOAI @matl int, @mads int
as
begin
	delete from DS_THELOAI where MaDauSach = @mads and MaTheLoai = @matl
end



