import { Component, OnInit } from '@angular/core';
import { SongItemService } from 'src/app/shared/song-item.service';

import { NgForm } from '@angular/forms';
import { SongItem } from 'src/app/shared/song-item.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-song-item-form',
  templateUrl: './song-item-form.component.html',
  styles: [
  ]
})
export class SongItemFormComponent implements OnInit {

  constructor(public service: SongItemService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.songId == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postSongItem().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Successfully')
      },
      err => { console.log(err); }
    );
  }

  updateRecord(form: NgForm) {
    this.service.putSongItem().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Updated successfully')
      },
      err => { console.log(err); }
    );
  }


  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new SongItem();
  }

}