namespace QuanLyDienNang
{
	public class STRINGS
	{
		public static readonly string ERROR = "Lỗi";
		public static readonly string ERROR_QUERY_MESSAGE = "Lỗi thực hiện truy vấn đến cơ sở dữ liệu.";
		public static readonly string ERROR_INSERT_MESSAGE = "Thêm dữ liệu mới vào không thành công.";
		public static readonly string ERROR_UPDATE_MESSAGE = "Cập nhật dữ liệu không thành công.";
		public static readonly string ERROR_DELETE_MESSAGE = "Xóa dữ liệu không thành công.";
		public static readonly string ERROR_SAVE_CNNSTR_MESSAGE = "Không thể lưu chuỗi kết nối, vui lòng kiểm tra lại các thông tin cho hợp lệ!";
		public static readonly string ERROR_CNNSTR_MESSAGE = "Kết nối đến cơ sở dữ liệu không thành công!";
		public static readonly string ERROR_EXPORT_MESSAGE = "Lỗi khi xuất dữ liệu sang tập tin Excel.";
		public static readonly string ERROR_IMPORT_MESSAGE = "Lỗi khi nhập dữ liệu từ tập tin Excel, vui lòng kiểm tra dữ liệu hợp lệ.";
		public static readonly string ERROR_PATH_MESSAGE = "Đường dẫn không hợp lệ hoặc không tìm thấy hình ảnh .jpg hay .png nào trong thư mục.";
		public static readonly string ERROR_OCR_MESSAGE = "Lỗi khi nhận diện số trên hình ảnh!";
		public static readonly string ERROR_COPY_MESSAGE = "Đã có lỗi khi sao chép dòng này.";
		public static readonly string ERROR_IMPORT_EXCEL = "Lỗi đọc dữ liệu từ tập tin Excel.";
		public static readonly string ERROR_NOT_FOUND_MESSAGE = "Không tìm thấy tập tin theo yêu cầu.";
		public static readonly string ERROR_DEACTIVATE_MESSAGE = "Hủy kích hoạt bản ghi không thành công.";
		public static readonly string ERROR_COMMIT_DATAGRIDVIEW_MESSAGE = "Đã có lỗi xảy ra khi nhận dữ liệu vào DataGridView: ";

		public static readonly string WARNING = "Cảnh báo";
		public static readonly string WARNING_MISS_FIELDS_MESSAGE = "Không được để trống các trường bắt buộc.";
		public static readonly string WARNING_DUPLICATE_MABANGGIA = "Mã bảng giá đã tồn tại trong CSDL, vui lòng thử mã khác.";
		public static readonly string WARNING_DUPLICATE_MATRAM = "Mã trạm đã tồn tại trong CSDL, vui lòng thử mã khác.";
		public static readonly string WARNING_MISS_DGV_MESSAGE = "Không thể thực hiện hành động này vì DataGridView đang trống.";
		public static readonly string WARNING_THREAD_MESSAGE = "Có một tiến trình tương tự đang chạy, bạn phải đợi cho tiến trình đó hoàn tất hoặc nhấn vào nút 'Dừng' và chạy lại!";
		public static readonly string WARNING_NO_SQL_CONNECTION_MESSAGE = "Bạn không thiết lập kết nối đến máy chủ SQL nên chương trình sẽ thoát tại đây!";
		public static readonly string WARNING_MISS_FILE_MESSAGE = "Phải chọn tập tin trước khi thực hiện hành động này.";
		public static readonly string WARNING_NO_PERCENT_MESSAGE = "Đây không phải là bảng điện áp giá.";
		public static readonly string WARNING_NO_APPLY_PERCENT_MESSAGE = "Vui lòng sử dụng nút 'Xem % áp giá'.";

		public static readonly string SUCCESS = "Thành công";
		public static readonly string SUCCESS_INSERT_MESSAGE = "Thêm dữ liệu mới vào thành công.";
		public static readonly string SUCCESS_UPDATE_MESSAGE = "Cập nhật dữ liệu thành công.";
		public static readonly string SUCCESS_DELETE_MESSAGE = "Xóa dữ liệu thành công.";
		public static readonly string SUCCESS_SAVE_CNNSTR_MESSAGE = "Lưu thành công chuỗi kết nối.";
		public static readonly string SUCCESS_CNNSTR_MESSAGE = "Kết nối đến cơ sở dữ liệu thành công!";
		public static readonly string SUCCESS_EXPORT_MESSAGE = "Xuất dữ liệu sang tập tin Excel thành công.";
		public static readonly string SUCCESS_COPY_MESSAGE = "Đã sao chép dữ liệu vào bộ nhớ tạm.";
		public static readonly string SUCCESS_DEACTIVATE_MESSAGE = "Hủy kích hoạt bản ghi thành công.";

		public static readonly string QUESTION = "Xác nhận";
		public static readonly string QUESTION_LAPDANHSACH_MESSAGE = "Chức năng này dùng để lập danh sách mới theo kỳ được xác định, dữ liệu lấy từ danh sách khách hàng. Bạn có muốn tiếp tục?";
		public static readonly string QUESTION_QUIT_MESSAGE = "Bạn có muốn thoát khỏi chương trình không?";
		public static readonly string WARNING_MISS_PATH_MESSAGE = "Phải chọn tập tin trước khi thực hiện hành động này.";

		public static readonly string SAMPLE_PATH = "/Templates/NhapThongTinKhachHang_Sample.xlsx";

	}
}
