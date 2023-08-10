import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  Output,
  SimpleChanges,
} from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss'],
})
export class PaginationComponent implements OnChanges {
  @Input() totalItemCount = 0;
  @Input() pageSize = 10;

  @Output() onSelectedPageIndex: EventEmitter<number> = new EventEmitter();

  pagesNumber = 1;
  selectedPageIndex = 1;

  ngOnChanges(changes: SimpleChanges): void {
    this.pagesNumber = Math.ceil(this.totalItemCount / this.pageSize);

    if (this.pagesNumber < this.selectedPageIndex) {
    }
  }

  public changePageIndex(index: number): void {
    if (index > 0 && index <= this.pagesNumber) {
      this.selectedPageIndex = index;
      this.onSelectedPageIndex.emit(this.selectedPageIndex);
    }
  }
}
