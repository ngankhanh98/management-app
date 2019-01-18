# Management Application
(Nên đặt tên mới phải)

## Giới thiệu
Management Applcation là đồ án cuối kì môn Lập trình windows.

Application hỗ trợ các chức năng cơ bản về CRUD dữ liệu, thống kê dữ liệu; đối tượng quản lý là hóa dược mỹ phẩm.

## Chức năng
### 🧮 Chức năng Master data (3 điểm)
- [x] Create: Tạo ra dữ liệu. Nhập liệu từng dòng bằng tay là yêu cầu cơ bản.
- [x] Read: Thường bắt đầu bằng hiển thị một danh sách. Với mỗi danh sách sẽ hiển thị chi tiết khi click vào.
- [x] Update: Cập nhật lại thông tin.
- [x] Delete: Thường nhóm dữ liệu master data không bao giờ bị xóa hoàn toàn khỏi cơ sở dữ liệu mà chỉ bị đánh dấu là xóa mà thôi.

### 🤝 Chức năng Transaction data (2 điểm)
- [x] Khi thanh toán các đơn hàng sẽ có nhiều trạng thái, có thể phải đi giao hàng thu tiền hoặc khách đặt cọc trước qua chuyển khoản chẳng hạn.
- [x] Khuyến mãi giảm giá như.

### 📈 Chức năng Report (4 điểm)
- [x] Thống kê sản phẩm bán chạy.
- [x] Thống kê theo doanh thu.
- [x] Thống kê theo ngày, theo tuần, theo tháng, theo quý, theo năm, theo nhiều năm
- [x] Thống kê trong khoảng thời gian từ ngày đến ngày
- [x] Sẽ có 3 dạng biểu đồ cần hỗ trợ: **đường, cột, bánh**

### 🎉 Good to have
- [ ] Sử dụng server tự dựng hoặc dịch vụ cơ sở dữ liệu trên mạng và từ đó kết nối tới.
- [ ] Generate ra installer.msi hoặc installer.exe
- [x] Ribbon
- [x] Beautyful Chart
- [x] Material design
- [x] Lọc theo một hoặc nhiều tiêu chí nào đó.
- [ ] Tìm kiếm theo một hoặc nhiều tiêu chí nào đó.

## Giao diện
### Main Windows
![](https://ucdd80b22543eb6be974dd60cbce.previews.dropboxusercontent.com/p/orig/AARYnv9_QB7ypQBwtZVbUFPrI-rhsc-KzDRgRe9M70V76P1UUYav6zbUXZAYUNtjvdHBFWHV-0JuJDSkFBHRbO06U928ae-K9aWUIMIYlgdZ_Lx4G2KhX3w_vkVjPsYi4uLrcq5edHAESnKV_77aFSGPbi3snVIbCzbyqegfOXfhfHVabc30GW_Nt_UnH714GFRT5coV3dRR8PHCYWf5bSDuQgInEZmxtT5t0OGyarTlgQ/p.gif?size=1280x960&size_mode=3)

### Thêm/Xóa một category
![](https://uc35a0a2c43c0883a542d7167669.previews.dropboxusercontent.com/p/orig/AAQNSvuGLEwqxLQ3OFCxm315VV36FVZvHB7deRDEvc5vDm_ooct9rECvNPyVK7WjmNYvz381B5d7bnGHhMsgBZv-EOFVm_FbRIHA8ThAS-U0qtjfMJ8ewRzTwJHcKCpVAdPv6yMdbO3oWPSTXl-7NT6NhM0MzKp-NDWe5fHBsUFlGY3FDop55zwc91DBXbWnm05TIPKXKHoDoruAylNrOyfDmZPUxuLo-XbXVWiWFc8wpw/p.gif?size=1280x960&size_mode=3)
![](https://uce336ba9b910020c2f11393c466.previews.dropboxusercontent.com/p/orig/AAQIjVrJ3k42xSlt8geWzvEz0zl8mWyUFRGKdv11cq6mikPIDfsnhVugFOimf6Qew6zFSVqZj3BLRlnfEXm8ZkZsvkegDI1lGlV3StrwTTun9JLFW5TvABZLxZw_apCnZ8j7s2PgFaTm3LIuTx-zWs2kJOOXfUkRwwRHwFGCl6l23ahMarHyeV8Id4rnjxqkRaNNF7JOQTTkCVRhA9f9jrYlL99melxWzxTYzRILGPm-6w/p.gif?size=1280x960&size_mode=3)

### Thêm/Xóa/Sửa product
![](https://uc78b3da56cbfd15bac7882af1ca.previews.dropboxusercontent.com/p/orig/AAQIlIm69PxIohuF22JvhTtajL48puL9sKSqjQPuH2CsXzWxA6rFFWjEw_FHQczvku-URtazzmNkASgVdEGb-dAfRSUg7i8pVhDc8PXB1SIFfhNsSyUWhTHUv2Yntgc6l9ExXaaPb_U22zJ3HjkUcVbztLy9eVA8ubJbdfVyq2VhMxvN1NrWm3_HE-bMA3WBupHtEs7FWct2DpxS2hIVFMV8MbEu3m4RTiQfCxQ1sU74Eg/p.gif?size=1280x960&size_mode=3)
![](https://uc29c1d63975db81530a97dad094.previews.dropboxusercontent.com/p/orig/AARu5ZCcWxg0Y48kW2eHritblRbtpo7bG7o4cPIWAXZTWKI9BzbH3DcRZmNRNKVEa7Xpc1Upad8m5tEsJVC8Qr1v1kyX4iwRuQoTNN9SJDTtY6hkk6w6FY16qaR--sTIILiXAgSNz89Uk97ePOOpbVmb-M1OxDAF8aZ-9cPfVMBjziyKS2y9x1U9ypPzGY4wHJBaZnOAxzhktIITacZX5S3wWjO_FR5HN-GOG---9EyhUA/p.gif?size=1280x960&size_mode=3)
![](https://uc407273c0dd687f1b2abbacfacf.previews.dropboxusercontent.com/p/orig/AAQPSLpxzlZ6CHoZzkE-PVBCnNzbBSyf3JlZJ9_nKhmvWHY05G1U517KkoJDqHRU1fetN_AhLlbVyTa4BnC7LqgA4gEyxHdghXoLfEswN42vYs68sC_9Rwz4q7r1hghSQGfHAgazxDYeFtBJsy0774iXkgQYGVwwGPimktsI0W6BSWYq_42miwvR8m938af06zXOvJVjXzhZ0YZDzwJfRI5X3SVz4_m98xmPpdSE3noDAA/p.gif?size=1280x960&size_mode=3)

### Thêm order
![](https://uca9ef63e28c3ce67d996eb90e2a.previews.dropboxusercontent.com/p/orig/AARg-5x7FTQRioF9_7rkLPDU8bQokP7Xc43RnTNOUs_afp0w37DWy8Xbzfq8ZI-ZfmNypXMA3UyZEOCF0-9M1OfydK_tuzfQTaRBMYCdi4wfCHWJ42fj-wz4CHkXuoO7wTO-ByEu532wNkSdseP4IDI2f6wl4hAmqf9NJD7_XdI4TPOsZfC5w0rNxe_k1scqz6mfRe2AOVM629sLHc0_-gj1mVod6FkSy_bwPMTPvTJ9IQ/p.gif?size=1280x960&size_mode=3)
### Thống kê & Biểu đồ
![](https://uc0c689e652860599201f0c7658d.previews.dropboxusercontent.com/p/orig/AASk2T6Ts42XxdZLVgQyZIoM1IK_nhLlrUmMtjcYB7og7gjQbFSwJCFsN78mmcgZzp9aHeNPcxvD-va_jQ0Lf0pMfoT0s-IqnGoSvz6ZQID-b6rtY4TSx4bMyHROXXd_Q3TXkgDyly1HZWU0djqbqUX9HcbrhBkqvK_0-aGhYvJAXpjaWEyIS-mSQLMx5WO19obE9BVh3AIZzhz-T3gyC0kUYiRLjEmqWEMFdq_6yUveqg/p.gif?size=1280x960&size_mode=3)

### Lọc
![](https://ucfa44e20d6c77b1e6de456ed42e.previews.dropboxusercontent.com/p/orig/AATypPqTuzF7BnC7TvgZ2TmXepRQqRWMS49o9UDPtgMT0Zk8YSmStDClKiXHYdK50eyDsK5zQNkx4Jy8T_Z4b1xKTQ47HLj0vur0QL0-ZhH-C1yp-Nw3f-A4rEWMCqloPdASGUtuVuT26RHi6trFAfyJ2j3HMovvNrQoXLjbeDVZV17eMEcmpz_9Ns3H_fA5kud8caf77v9A63JLZ2482p7vEzceVEpNmL4p3Tt25ZsUlg/p.gif?size=1280x960&size_mode=3)


## Video demo
URL: [Lập trình Windows. Đồ án cuối kỳ Ứng dụng quản lý](https://www.youtube.com/watch?v=k_ITufuh_xA)

## Bên lề:
Xem thêm TODO list tại [đây](https://github.com/ngankhanh98/management-app/projects/2)
Xem thêm issuses (nếu có) tại [đây](https://github.com/ngankhanh98/management-app/issues)
Xem thêm các tài liệu liên quan (nếu có) tại [đây](https://github.com/ngankhanh98/management-app/wiki)
Vui lòng tải bản release tài đây.
