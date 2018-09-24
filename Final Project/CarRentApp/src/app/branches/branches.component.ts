import { Component, OnInit } from '@angular/core';
import { Branch } from '../shared/models/branch.model';
import { BranchService } from '../shared/services/branch.service';

@Component({
  selector: 'app-branches',
  templateUrl: './branches.component.html',
  styleUrls: ['./branches.component.css']
})
export class BranchesComponent implements OnInit {
  zoom: number = 11;
  public branches: Branch;
lat:number = 32.077818;
lng:number =  34.785233;
  constructor(private myService:BranchService) { }

  ngOnInit() {
    this.myService.getAllBranches().subscribe(data => {this.branches = data});
  }


}
