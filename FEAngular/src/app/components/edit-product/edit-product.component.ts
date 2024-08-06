import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { AuthService } from '../../services/auth.service';
import ValidateForm from '../../helpers/validationform';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrl: './edit-product.component.scss'
})
export class EditProductComponent implements OnInit {
  public EditProductForm!: FormGroup;
  public products : any = [];
  constructor(private fb : FormBuilder , private api : ApiService ,private auth : AuthService){}
  
  ngOnInit(): void {
     this.EditProductForm = this.fb.group({
      productID: ['', Validators.required],
      productName: ['', Validators.required],
      price :['', Validators.required]
    });
  }

  getallproduct(){
    this.api.getallproduct().subscribe(res => {
      this.products=res;  
    });
  }

  onEdit() {
    if (this.EditProductForm.valid) {
      console.log(this.EditProductForm.value);
      this.api.updateProduct(this.EditProductForm.value).subscribe({
        next: (res) => {
          console.log(res.message); 
          alert("Sửa thành công");
          this.getallproduct();
          
        },
        error: (err) => {
          console.log(err);          
          alert("Sửa thất bại")
        },
      });
    } else {
      ValidateForm.validateAllFormFields(this.EditProductForm);
      alert("Form Invalid");
    }
  }
}
