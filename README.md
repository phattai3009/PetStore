# Thành Viên
| MSSV          | Họ tên                   | Nội Dung Thực Hiện                              |
|---------------|--------------------------|-------------------------------------------------|
| 2001190243    | Đinh Phát Tài            | Design - Code chính - SQL - Phân Tích Nghiệp Vụ |
| 2001190249    | Lê Nguyễn Đại Đức Tâm    | Code phụ - Thiết kế SQL - Word                  |

# Giới Thiệu Phần Mền Quản Lý Cửa Hàng Thú Cưng - Introducing Pet Store Management Software
Phần mền quản lý cửa hàng thú cưng - Pet Store Management Software

Hệ thống quản lý cửa hàng mua bán thú cưng còn được biết đến là hàng loạt những công việc được người phụ trách mảng này làm đi làm lại trong một khoảng thời gian dài nhất định. Đó có thể là nhận thú cưng trực tiếp từ khách hàng, hoặc gián tiếp qua email, điện thoại, mạng xã hội (zalo, facebook…),…

Hiện nay, hệ thống quản lý cửa hàng mua bán thú cưng chủ yếu được ứng dụng từ những phần mềm quản lý bán hàng. Điều này, giúp chủ cửa hàng kiểm soát , quản lý lượng hàng hóa một cách chặt chẽ. Việc quản lý của hệ thống sẽ được thể hiện cụ thể qua các khâu: quản lý thú cưng, quản lý kho, quản lý nhân viên, quản lý mua nhập thú cưng,…
Trong thời đại công nghệ phát triển mạnh mẽ như hiện nay, thì các phần mềm quản lý trở thành công cụ hữu ích hơn bao giờ hết cho hoạt động quản lý bán hàng.
Hệ thống quản lý cửa hàng mua bán thú cưng là một phương thức để chủ doanh nghiệp có thể giám sát được hoạt động bán hàng của nhân viên. Đồng thời, xem xét tính trung thực của nhân viên bán hàng

- [x] Các thư viện hỗ trợ trong phần mền
  - [Thư viện hỗ trợ đọc QRCode ZXing](https://en.wikipedia.org/wiki/Barcode_Scanner_(application))
  - [Thư viện hỗ trợ lấy video AForge.NET](http://www.aforgenet.com/aforge/framework/samples/video.html)
  - [Thư viện hỗ trợ chỉnh sửa giao diện](https://gunaui.com/)
  - [Mã hoá mật khẩu MD5](https://vi.wikipedia.org/wiki/MD5)
  - [Thư viện hỗ trợ Report hoá đơn](https://www.nuget.org/packages/CrystalDecisions.CrystalReports/)
  - [Thông tin xuất Excel](https://docs.microsoft.com/en-us/dotnet/api/microsoft.office.interop.excel?view=excel-pia)

# Chức năng và nghiệp vụ của PetStore
Phần mền quản lý cửa hàng thú cưng - Pet Store Management Software
- [x] Chức năng danh mục
  - Quản lý quyền đăng nhập hệ thống ✓
    - Nội dụng: Chức năng cho phép tài khoản của nhân viên đăng nhập với loại quyền của mình được set trong hệ thống.
  - Quản lý thông tin nhân viên ✓
    - Nội dung: Chức năng cho phép quản lý có thể thêm xoá sửa các nhân viên có trong hệ thống.
  - Quản lý giống, loài thú cưng ✓
    - Nội dung: Chức năng cho phép quản lý có thể thêm xoá sửa các giống và loài của thú cưng được bán trong cửa hàng.
  - Quản lý thông tin khách hàng ✓
    - Nội dung: Chức năng cho phép quản lý hay nhân viên có thể thêm xoá sửa khách hàng khi đến với hệ thống cửa hàng.
  - Quản lý nhà cung cấp thú cưng ✓
    - Nội dung: Chức năng cho phép quản lý có thể thêm xoá sửa các nhà cung cấp thú cưng cho cửa hàng.
  - Quản lý đơn hàng ✓
    - Nội dung: Chức năng cho phép quản lý có thể xem và sửa nội dung của các đơn hàng đã bán.
  - Quản lý danh sách đơn đổi trả ✓
    - Nội dung: Chức năng cho phép quản lý có thể xem và sửa nội dung của các đơn đã được đổi trả.
- [x] Chức năng nghiệp vụ:
  - Chức năng bán thú cưng: ✓
    - Nội dung: Chức năng cho phép nhân viên hay quản lý có thể bán thú cưng cho khách hàng. Thú cưng sẽ được thêm vào giỏ hàng bẳng tay hoặc có thể quét mã QRCode. Hệ thống chỉ lưu đơn hàng lại khi khách hàng thanh toán đơn hàng.
  - Chức năng đặt mua hàng: ✓
    - Nội dung: Chức năng cho phép quản lý sẽ đặt mua những giống thú cưng với số lượng của giống đó từ nhà cung đã có trong hệ thống.
  - Chức năng nhập hàng: ✓
    - Nội dung: Chức năng cho phép quản lý nhập những đơn hàng đã được giao đến khi đặt mua từ nhà cung cấp đó. Khi nhập hàng quản lý sẽ chọn đơn đặt mua từ trước, hệ thống sẽ xuất ra những giống đã đặt mua và chỉ cho phép nhập đủ số lượng đã đặt mua từ trước. Khi nhập hàng hệ thống sẽ tạo ra thú cưng đã nhập với vào những thông tin như mã thú cưng, tên thú cưng, giá bán, ngày tạo, mã giống, mã loài,... ngoài rà hệ thống sẽ tự tạo mã QRCode cho thú cưng nhầm phục vụ cho chức năng bán thú cưng.
  - Chức năng đổi trả: ✓
    - Nội dung: Chức năng cho phép quản lý có thể đổi trả những thú cưng mà khách hàng có nhu cầu đổi trả vì lý do khách quan. Hệ thống chỉ cho phép 1 đơn hàng có thể đổi trả 1 lần duy nhất, ngoài ra hệ thống sẽ kiểm tra tình trạng đơn hàng nếu đơn hàng quá 15 ngày được tính từ ngày mua thì hệ thống sẽ không cho phép đổi trả.

#  Demo
Click ảnh để xem demo ⇓
[![Watch the video](https://i.imgur.com/Y3FFgYl.png)](https://firebasestorage.googleapis.com/v0/b/qlvideoimage.appspot.com/o/VideoThuyetTrinhDoAn.mp4?alt=media&token=d04826f3-76e5-437d-b0a4-cd0669516c1d)
