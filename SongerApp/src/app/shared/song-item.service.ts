import { Injectable } from '@angular/core';
import { SongItem } from 'src/app/shared/song-item.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class SongItemService {

  constructor(private http: HttpClient) { }

  readonly baseURL = 'http://localhost:52915/api/SongItem'
  formData: SongItem = new SongItem();
  list: SongItem[];

  postSongItem() {
    return this.http.post(this.baseURL, this.formData);
  }

  putSongItem() {
    return this.http.put(`${this.baseURL}/${this.formData.songId}`, this.formData);
  }

  deleteSongItem(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList() {
    this.http.get(this.baseURL)
      .toPromise()
      .then(res =>this.list = res as SongItem[]);
  }


}