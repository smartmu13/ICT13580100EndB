using System;
using System.Collections.Generic;
using ICT13580100EndB.Models;
using Xamarin.Forms;

namespace ICT13580100EndB
{
    public partial class ProductCarPage : ContentPage
    {
        ProductCar carproduct;
        public ProductCarPage(ProductCar carProduct=null)
        {
            InitializeComponent();

            this.carproduct= carProduct;
            titleLabel.Text = carproduct == null ? "เพิ่มข้อมูล":"แก้ไขข้อมูล";    
            saveButton.Clicked += SaveButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;


            tyepPicker.Items.Add("รถเก๋ง");
            tyepPicker.Items.Add("รถกะบะ");
            tyepPicker.Items.Add("รถตู้");

            brandPicker.Items.Add("นิสสัน");
			brandPicker.Items.Add("อีซูซุ");
			brandPicker.Items.Add("บีเอ็มดับเบิลยู");

			colorPicker.Items.Add("แดง");
			colorPicker.Items.Add("ขาว");
			colorPicker.Items.Add("ดำ");
			colorPicker.Items.Add("เงิน");

			provincePicker.Items.Add("กรุงเทพ");
			provincePicker.Items.Add("ปทุมธานี");
			provincePicker.Items.Add("พระนครศรีอยุธยา");
			provincePicker.Items.Add("เพรชบุรี");

        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกหรือไม่", "ใช่", "ไม่ใช่");
            if(isOk)
            {
                if(carproduct == null)
                {
                    carproduct = new ProductCar();
                    carproduct.Category = tyepPicker.SelectedItem.ToString();
                    carproduct.Brand = brandPicker.SelectedItem.ToString();
                    carproduct.Gen = productNameEntry.Text;
                    carproduct.Years = decimal.Parse(YearStepper.Text);
                    carproduct.Miles = decimal.Parse(mileEntry.Text);
                    carproduct.Color = colorPicker.SelectedItem.ToString();
				
                    carproduct.Deler = deronEntry.Text;
                    carproduct.Description = detailsEntry.Text;
                    carproduct.Price = decimal.Parse(priceEntry.Text);
                    carproduct.Province = provincePicker.SelectedItem.ToString();
                    carproduct.Tel = decimal.Parse(tellEntry.Text);
                    var id = App.DbHelper.AddProduct(carproduct);
                await DisplayAlert("บันทึกสำเส็จ", "รหัสรถของท่าน" + id, "ตกลง");
                    }
                else
                {
					carproduct = new ProductCar();
					carproduct.Category = tyepPicker.SelectedItem.ToString();
					carproduct.Brand = brandPicker.SelectedItem.ToString();
					carproduct.Gen = productNameEntry.Text;
					carproduct.Years = decimal.Parse(YearStepper.Text);
					carproduct.Miles = decimal.Parse(mileEntry.Text);
					carproduct.Color = colorPicker.SelectedItem.ToString();

					carproduct.Deler = deronEntry.Text;
					carproduct.Description = detailsEntry.Text;
					carproduct.Price = decimal.Parse(priceEntry.Text);
					carproduct.Province = provincePicker.SelectedItem.ToString();
					carproduct.Tel = decimal.Parse(tellEntry.Text);
					var id = App.DbHelper.AddProduct(carproduct);
					await DisplayAlert("บันทึกสำเส็จ", "แก้ไขสินค้าเส็จแล้ว", "ตกลง");   
                }
                await Navigation.PopModalAsync();

            }
        }

        void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
