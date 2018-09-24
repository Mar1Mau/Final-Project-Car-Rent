import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { User } from "../models/user.model";
import { Observable, } from "rxjs/Observable";

@Injectable()
export class UserService {

    myUIrl: string = 'http://localhost:12288/api/Users';

 
    constructor(private myHttpClient: HttpClient) { }

    public getAllUsers(): Observable<User> {
        return this.myHttpClient.get<User>(this.myUIrl);
    }

    public getUserByUserNameAndPsswd(userName:string,passwd:string):Observable<User>{
        return this.myHttpClient.get<User>(`http://localhost:12288/api/Users/${userName}/${passwd}`);
    }

    public addUser(user: User, callback: (bool: boolean) => void): void {
        this.myHttpClient.post(this.myUIrl, JSON.stringify(user), { headers: { "content-type": "application/json" } }).subscribe(() => { this.getAllUsers(); callback(true); },
            () => { callback(false) });

    }

    public editUser(user: User, userName: string, callback: (bool: boolean) => void): void {
        this.myHttpClient.put<boolean>(`${this.myUIrl}?UserName=${userName}`, JSON.stringify(user), { headers: { "content-type": "application/json" } })
           .subscribe(() => { this.getAllUsers(); callback(true); },
               () => { callback(false) });
    }

 
   

    getUserForEdit(userName:string,callback:(user:User)=>void): void {
        this.myHttpClient.get(`${this.myUIrl}?UserName=${userName}`)
           .subscribe((x:User) => { callback(x);});
    }


    public deleteUser(userName: string): Observable<User> {
        let apiUrl: string = `${this.myUIrl}?UserName=${userName}`;
        return this.myHttpClient.delete<User>(apiUrl);
    }

   
  
    logout() {
      localStorage.removeItem('currentUser');
    }

   
}