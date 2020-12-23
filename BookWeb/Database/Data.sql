
use BookStore
go

--Delete AccountGroup---
--select * from AccountGroup
Insert into AccountGroup(id,name) values('Admin', 'Quan Ly Trang')
Insert into AccountGroup(id,name) values('Member', 'Khach Hang')


--Delete Account--
--select * from Account
Insert into Account(username,password,name,address,birthday,email,phone,gender,groupid,status) values ('admin','21232f297a57a5a743894a0e4a801fc3',N'Hoài Phong',N'Cần Thơ','09-19-2000','truongphuc271100@gmail.com',0373200876,1,'Admin',1)
Insert into Account(username,password,name,address,birthday,email,phone,gender,groupid,status) values ('member','aa08769cdcb26674c6706093503ff0a3',N'Member1',N'Ca Mau','03-29-2000','ttlapa18081@cusc.ctu.edu.vn',0123456789,1,'Member',1)
Insert into Account(username,password,name,address,birthday,email,phone,gender,groupid,status) values ('member1','e10adc3949ba59abbe56e057f20f883e',N'Member1',N'Ca Mau','03-29-2000','ttlapa18081@cusc.ctu.edu.vn',0123456789,1,'Member',1)

--Category--
--select * from Category
Insert into Category(name,metatitle,status) values(N'English Sub','english-sub','1')
Insert into Category(name,metatitle,status) values(N'Khoa Hoc','khoa-hoc','1')
Insert into Category(name,metatitle,status) values(N'Sach Giao Khoa','sach-giao-khoa','1')
Insert into Category(name,metatitle,status) values(N'Tam Ly','tam-ly','1')
Insert into Category(name,metatitle,status) values(N'Song Ngu','song-ngu','1')
Insert into Category(name,metatitle,status) values(N'Tan Van','tan-van','1')
Insert into Category(name,metatitle,status) values(N'Tieu Thuyet','tieu-thuyet','1')
Insert into Category(name,metatitle,status) values(N'Tu Dien','tu-dien','1')

--Book--
--delete from Book
--select * from Book
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 1','demo-1','Author 1',1,123.000,1,'/Asests/clients/Image/EngSub/1.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 2','demo-2','Author 1',1,123.000,1,'/Asests/clients/Image/EngSub/2.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 3','demo-3','Author 1',1,123.000,1,'/Asests/clients/Image/EngSub/3.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 4','demo-4','Author 1',1,123.000,1,'/Asests/clients/Image/EngSub/4.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 5','demo-5','Author 1',2,123.000,1,'/Asests/clients/Image/khoahoc/1.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 6','demo-6','Author 1',2,123.000,1,'/Asests/clients/Image/khoahoc/2.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 7','demo-7','Author 1',2,123.000,1,'/Asests/clients/Image/khoahoc/3.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 8','demo-8','Author 1',2,123.000,1,'/Asests/clients/Image/khoahoc/4.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 9','demo-9','Author 1',3,123.000,1,'/Asests/clients/Image/sgk/1.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 10','demo-10','Author 1',3,123.000,1,'/Asests/clients/Image/sgk/2.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 11','demo-11','Author 1',3,123.000,1,'/Asests/clients/Image/sgk/3.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 12','demo-12','Author 1',3,123.000,1,'/Asests/clients/Image/sgk/4.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 13','demo-13','Author 1',4,123.000,1,'/Asests/clients/Image/songngu/1.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 14','demo-14','Author 1',4,123.000,1,'/Asests/clients/Image/songngu/2.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 15','demo-15','Author 1',4,123.000,1,'/Asests/clients/Image/songngu/3.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 16','demo-16','Author 1',4,123.000,1,'/Asests/clients/Image/songngu/4.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 17','demo-17','Author 1',5,123.000,1,'/Asests/clients/Image/tamly/1.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 18','demo-18','Author 1',5,123.000,1,'/Asests/clients/Image/tamly/2.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 19','demo-19','Author 1',5,123.000,1,'/Asests/clients/Image/tamly/3.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 20','demo-20','Author 1',5,123.000,1,'/Asests/clients/Image/tamly/4.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 21','demo-21','Author 1',6,123.000,1,'/Asests/clients/Image/tanvan/1.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 22','demo-22','Author 1',6,123.000,1,'/Asests/clients/Image/tanvan/2.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 23','demo-23','Author 1',6,123.000,1,'/Asests/clients/Image/tanvan/3.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 24','demo-24','Author 1',6,123.000,1,'/Asests/clients/Image/tanvan/4.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 25','demo-25','Author 1',7,123.000,1,'/Asests/clients/Image/tieuthuyet/1.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 26','demo-26','Author 1',7,123.000,1,'/Asests/clients/Image/tieuthuyet/2.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 27','demo-27','Author 1',8,123.000,1,'/Asests/clients/Image/tudien/1.jpg')
Insert into Book(name,metatitle,author,idCategory,price,status,image) values('Demo 28','demo-28','Author 1',8,123.000,1,'/Asests/clients/Image/tudien/2.jpg')

--Menu Type--

Insert into MenuType(name) values(N'Menu Chinh')
Insert into MenuType(name) values(N'Menu Phu')

--Menu--

--delete from Menu
Insert into Menu(name,link,displayorder,status,typeid) values('Trang Chu','/',1,1,1)
Insert into Menu(name,link,displayorder,status,typeid) values('Gioi Thieu','/gioi-thieu',3,1,1)
Insert into Menu(name,link,displayorder,status,typeid) values('San Pham','/san-pham',2,1,1)
Insert into Menu(name,link,displayorder,status,typeid) values('Discount','/discount',4,1,1)
Insert into Menu(name,link,displayorder,status,typeid) values('Dang Nhap','/dang-nhap',1,1,2)
Insert into Menu(name,link,displayorder,status,typeid) values('Dang Ky','/dang-ky',2,1,2)
Insert into Menu(name,link,displayorder,status,typeid) values('Doi Mat Khau','/doi-mat-khau',3,1,2)

---Slide--

--select * from Menu