﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Scada.Master" AutoEventWireup="true" CodeBehind="HongXuat8.aspx.cs" Inherits="Web_XANGDAU.WebForms.HongXuat8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/Online_Scada.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="tank_title">
                        <i class="bi bi-droplet-half" style="background:#41f1b6;"></i>
                        <span class="title_Tank">Họng 8 - E5 Tank 2</span>
                    </div>
                    <div class="tank" id="E5">
                        <img src="../Images/Scada_TwoTank.png" alt="" class="box E5">
                        <div class="symbol_E5">
                           <asp:Image ID="SVanXuat_E100_1" src="../Images/Symbol/Van_1_E5.png" class="box SVanXuat_E100" runat="server" />
                            <asp:Image ID="SVanXuat_E100_2" src="../Images/Symbol/Van_2_E5.png" class="box SVanXuat_E100" runat="server" />
                            <asp:Image ID="SVanXuat_RON92_1" src="../Images/Symbol/Van_1_E5.png" class="box SVanXuat_RON92" runat="server" />
                            <asp:Image ID="SVanXuat_RON92_2" src="../Images/Symbol/Van_2_E5.png" class="box SVanXuat_RON92" runat="server" />
                            <asp:Image ID="SVanXuat_E5_1" src="../Images/Symbol/Van_1_E5.png" class="box SVanXuat_E5" runat="server" />
                            <asp:Image ID="SVanXuat_E5_2" src="../Images/Symbol/Van_2_E5.png" class="box SVanXuat_E5" runat="server" />
                            <asp:Image ID="SBomXuat_E100_1" src="../Images/Symbol/Bom_1_E5.png" class="box SBomXuat_E100" runat="server" />
                            <asp:Image ID="SBomXuat_E100_2" src="../Images/Symbol/Bom_2_E5.png" class="box SBomXuat_E100" runat="server" />
                            <asp:Image ID="SBomXuat_RON92_1" src="../Images/Symbol/Bom_1_E5.png" class="box SBomXuat_RON92" runat="server" />
                            <asp:Image ID="SBomXuat_RON92_2" src="../Images/Symbol/Bom_2_E5.png" class="box SBomXuat_RON92" runat="server" />
                            <asp:Image ID="SMucHH_E100_2" src="../Images/Symbol/MucE5_2.png" class="box SMucHH_E100" runat="server" />
                            <asp:Image ID="SMucH_E100_2" src="../Images/Symbol/MucE5_2.png" class="box SMucH_E100" runat="server" />
                            <asp:Image ID="SMucL_E100_1" src="../Images/Symbol/MucE5_1.png" class="box SMucL_E100" runat="server" />
                            <asp:Image ID="SMucL_E100_2" src="../Images/Symbol/MucE5_2.png" class="box SMucL_E100" runat="server" />
                            <asp:Image ID="SMucLL_E100_1" src="../Images/Symbol/MucE5_1.png" class="box SMucLL_E100" runat="server" />
                            <asp:Image ID="SMucLL_E100_2" src="../Images/Symbol/MucE5_2.png" class="box SMucLL_E100" runat="server" />
                            <asp:Image ID="SMucHH_RON92_2" src="../Images/Symbol/MucE5_2.png" class="box SMucHH_RON92" runat="server" />
                            <asp:Image ID="SMucH_RON92_2" src="../Images/Symbol/MucE5_2.png" class="box SMucH_RON92" runat="server" />
                            <asp:Image ID="SMucL_RON92_1" src="../Images/Symbol/MucE5_1.png" class="box SMucL_RON92" runat="server" />
                            <asp:Image ID="SMucL_RON92_2" src="../Images/Symbol/MucE5_2.png" class="box SMucL_RON92" runat="server" />
                            <asp:Image ID="SMucLL_RON92_1" src="../Images/Symbol/MucE5_1.png" class="box SMucLL_RON92" runat="server" />
                            <asp:Image ID="SMucLL_RON92_2" src="../Images/Symbol/MucE5_2.png" class="box SMucLL_RON92" runat="server" />
                            <asp:Image ID="SXe_E5" src="../Images/Symbol/Xe.png" class="box SXe_E5" runat="server" />   
                        </div>
                        <div class="box progress" style="height: 30px;background: #11101d;" id="pro51">
                            <asp:Panel ID="pn_MucPer_E100" class="progress-bar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width:60%;" runat="server">
                                 <asp:Label ID="lbl_MucPer_E100" runat="server" Text="---" ForeColor="White"></asp:Label>
                             </asp:Panel>
                        </div>
                        <div class="box progress" style="height: 30px;background: #11101d;" id="pro52">
                            <asp:Panel ID="pn_MucPer_RON92" class="progress-bar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width:60%;" runat="server">
                                 <asp:Label ID="lbl_MucPer_RON92" runat="server" Text="---" ForeColor="White"></asp:Label>
                             </asp:Panel>
                        </div>
                        <div class="box output">
                            <asp:TextBox ID="txt_VanXuatE100" type="number" min="0" max="100" class="form-control-sm textbox VanXuatE100" runat="server" ReadOnly="True" ToolTip="Độ mở van xuất E100"></asp:TextBox>
                            <asp:TextBox ID="txt_VanXuatRON92b" type="number" min="0" max="100" class="form-control-sm textbox VanXuatRON92" runat="server" ReadOnly="True" ToolTip="Độ mở van xuất RON92"></asp:TextBox>
                            <asp:TextBox ID="txt_VanXuatE5" type="number" min="0" max="100" class="form-control-sm textbox VanXuatE5" runat="server" ReadOnly="True" ToolTip="Độ mở van xuất E5"></asp:TextBox>
                            <asp:TextBox ID="txt_LuuLuongXuatE100" type="number" min="0" max="100" class="form-control-sm textbox LuuLuongXuatE100" runat="server" ReadOnly="True" ToolTip="Lưu lượng xuất E100"></asp:TextBox>
                            <asp:TextBox ID="txt_LuuLuongXuatRON92" type="number" min="0" max="100" class="form-control-sm textbox LuuLuongXuatRON92" runat="server" ReadOnly="True" ToolTip="Lưu lượng xuất RON92"></asp:TextBox>
                            <asp:TextBox ID="txt_MucE100" type="number" min="0" max="100" class="form-control-sm textbox MucE100" runat="server" ReadOnly="True" ToolTip="Mức E100"></asp:TextBox>
                            <asp:TextBox ID="txt_MucRON92" type="number" min="0" max="100" class="form-control-sm textbox MucRON92" runat="server" ReadOnly="True" ToolTip="Mức RON92"></asp:TextBox>
                            <asp:TextBox ID="txt_NhietDoE100" type="number" min="0" max="100" class="form-control-sm textbox NhietDoE100" runat="server" ReadOnly="True" ToolTip="Nhiệt độ E100"></asp:TextBox>
                            <asp:TextBox ID="txt_NhietDoRON92" type="number" min="0" max="100" class="form-control-sm textbox NhietDoRON92" runat="server" ReadOnly="True" ToolTip="Nhiệt độ RON92"></asp:TextBox>
                        </div>
                        <div class="box GiamSat">
                            <table class="table-sm table-hover">
                                <thead>
                                  <tr>
                                    <th>Thông số</th>
                                    <th>Trạng thái</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Kết nối</td>
                                        <td><asp:Label ID="lbl_KetNoi" runat="server" Text="Chưa kết nối" ForeColor="Red"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Tiếp địa</td>
                                        <td><asp:Label ID="lbl_TiepDia" runat="server" Text="Chưa đảm bảo" ForeColor="Red"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Nhiệt độ</td>
                                        <td><asp:Label ID="lbl_NhietDo" runat="server" Text="---"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Mức</td>
                                        <td><asp:Label ID="lbl_Muc" runat="server" Text="---"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Đầu xuất</td>
                                        <td><asp:Label ID="lbl_DauXuat" runat="server" Text="Chưa gắn chặt" ForeColor="Red"></asp:Label></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="box DonXuat">
                            <div>
                                <label>Mã đơn xuất:</label>
                                <asp:TextBox ID="txt_MaDonXuat" type="text" class="form-control-sm txt_MaDon" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div>
                                <label>Cần xuất:</label>
                                <asp:TextBox ID="txt_TheTichCanXuat" type="text" class="form-control-sm text-center txt_TheTichCan" runat="server" ReadOnly="True"></asp:TextBox>
                                <labe>(m3)</labe>
                            </div>
                            <div>
                                <label>Đã xuất:</label>
                                <asp:TextBox ID="txt_TheTichDaXuat" type="text" class="form-control-sm text-center txt_TheTichDaBom" runat="server" ReadOnly="True"></asp:TextBox>
                                <label>(m3)</label>
                            </div>
                            <div>
                                <asp:Button ID="btn_XuatLieu" type="button" class="btn btn-success btn_Bom" runat="server" Text="Nhập liệu" />
                                <asp:Button ID="btn_DungXuat" type="button" class="btn btn-danger btn_DungBom" runat="server" Text="Dừng nhập" />
                            </div>
                        </div>   
                        <div class="box DonGia">
                            <div>
                                <label>Sản phẩm:</label>
                                <asp:TextBox ID="txt_SanPham" type="text" class="form-control-sm text-center txt_SanPham" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div>
                                <label>Đơn giá:</label>
                                <asp:TextBox ID="txt_DonGia" type="text" class="form-control-sm text-center txt_DonGia" runat="server" ReadOnly="True"></asp:TextBox>
                                <label>(VND/l)</label>
                            </div>
                            <div>
                                <label>Thành tiền:</label>
                                <asp:TextBox ID="txt_ThanhTien" type="text" class="form-control-sm text-center txt_ThanhTien" runat="server" ReadOnly="True"></asp:TextBox>
                                <label>(trVND)</label>
                            </div>
                            <div>
                                <label>Trạng thái:</label>
                                <asp:TextBox ID="txt_TrangThai" type="text" class="form-control-sm text-center txt_TrangThai" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="box Dem"></div>
                    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        $("#Scada").addClass('active');
    </script>
</asp:Content>
