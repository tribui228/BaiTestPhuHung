import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { ApiService } from '../../services/api.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import ValidateForm from '../../helpers/validationform';

interface Product {
  id: number;
  productID: string; 
  productName: string;
  price: number;
}
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})

export class DashboardComponent implements OnInit {
  public filteredProducts: any = [];
  public products : any = [];
  public username : string = "Minh Trí";
  public role : string = 'user';
  public AddProductForm!: FormGroup;
  public EditProductForm!: FormGroup;
  public searchControl: FormControl = new FormControl('');
  constructor(private fb : FormBuilder,private api : ApiService,private auth : AuthService){}

  ngOnInit(): void {
    this.getallproduct();

    this.AddProductForm = this.fb.group({
      productID: ['', Validators.required],
      productName: ['', Validators.required],
      price :['', Validators.required]
    });

    this.EditProductForm = new FormGroup({
      id: new FormControl('', [Validators.required]),
      productID: new FormControl('', [Validators.required]),
      productName: new FormControl('', [Validators.required]),
      price: new FormControl(0,   
   [Validators.required, Validators.min(0)])
    });

     // Subscribe to search control changes
     this.searchControl.valueChanges.subscribe(value => {
      this.filterProducts(value);
    });
  }

  filterProducts(searchTerm: string): void {
    if (!searchTerm) {
      this.filteredProducts = this.products;
    } else {
      this.filteredProducts = (this.products as any[]).filter((product: any) =>
        (product.productName as string).toLowerCase().includes(searchTerm.toLowerCase()) ||
        (product.productID as string).toLowerCase().includes(searchTerm.toLowerCase()) ||
        (product.price as number).toString().includes(searchTerm)
      );
    }
  
    // Check if filteredProducts is null or empty and set it to products if needed
    if (!this.filteredProducts || this.filteredProducts.length === 0) {
      this.filteredProducts = this.products;
    }
  }
  
  getallproduct(){
    this.api.getallproduct().subscribe(res => {
      this.products=res;  
      this.filteredProducts = this.products;
      console.log(this.products)
    });
  }
  logout(){
    this.auth.signOut();
  }

  onSubmit() {
    if (this.AddProductForm.valid) {
      console.log(this.AddProductForm.value);
      this.api.AddProducts(this.AddProductForm.value).subscribe({
        next: (res) => {
          console.log(res.message); 
          alert("thêm thành công");
          this.getallproduct();
          
        },
        error: (err) => {
          console.log(err);          
          alert("thêm thất bại")
        },
      });
    } else {
      ValidateForm.validateAllFormFields(this.AddProductForm);
      alert("Form Invalid");
    }
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
  deleteProduct(productId: number): void {
    this.api.deleteProduct(productId).subscribe(() => {
      this.getallproduct();
    });
  }
  openEditModal(item: any): void {
    // Cập nhật dữ liệu vào form
    console.log(item);
    this.EditProductForm.patchValue(item);   
  }

  
}
