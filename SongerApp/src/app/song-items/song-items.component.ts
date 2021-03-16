import { Component, OnInit } from '@angular/core';
import { SongItem } from 'src/app/shared/song-item.model';
import { SongItemService } from 'src/app/shared/song-item.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-song-items',
  templateUrl: './song-items.component.html',
  styles: [
  ]
})
export class SongItemsComponent implements OnInit {


  title: string;
  constructor(public service: SongItemService, 
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }
  
  populateForm(selectedRecord: SongItem) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this song?')) {
      this.service.deleteSongItem(id)
        .subscribe(
          res => {
            this.service.refreshList();
            this.toastr.error("Deleted successfully");
          },
          err => { console.log(err) }
        )
    }
  }

  Search(){

    if(this.title !=""){

      this.service.list = this.service.list.filter(res=>{
        return res.songTitle.toLocaleLowerCase().match(this.title.toLocaleLowerCase())
      });
      
    }else if(this.title ==""){
      this.ngOnInit();
    }
  }

}
