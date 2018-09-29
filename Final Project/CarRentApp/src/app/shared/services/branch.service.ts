import { Branch } from "../models/branch.model";
import { Injectable } from "@angular/core";
import { HttpClient} from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import { BranchList } from "../models/branchList.model";

@Injectable()
export class BranchService{

    myUIrl: string = 'http://localhost:12288/api/Branches';

    branchInfo:BranchList = new BranchList(); 

    branches:Branch;

    constructor(private myHttpClient: HttpClient) {
        
     }

    public getAllBranches():Observable<Branch> {
        return this.myHttpClient.get<Branch>(this.myUIrl);
    }

    
}

