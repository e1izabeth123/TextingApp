import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Input } from '@angular/core';
import { OutletContext } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  // @Input() usersFromHomeComponent: any
  @Output() cancelRegister =new EventEmitter();

  model : any ={}
  user :any;

  constructor(private accountService: AccountService, private toastr:ToastrService){}

  ngOnInit(): void {
    
  }

  register(){
    this.accountService.register(this.model).subscribe({
      next : response => {
        console.log(response);
        this.cancel();
      },
      error: error =>{
        console.log(error)
        this.toastr.error(error.error)

      }
      
    })
  }

cancel(){
  this.cancelRegister.emit(false);
}

}
