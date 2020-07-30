import { Component } from '@angular/core';

@Component({
  selector: 'test',
  templateUrl: './test.component.html'
})

export class TestComponent {
  public models: MyModel[];

  constructor() {
    this.models = [
      { 'first': 'first1', 'second': 'second1', 'third': 'third1' },
      { 'first': 'first2', 'second': 'second2', 'third': 'third2' },
      { 'first': 'first3', 'second': 'second3', 'third': 'third3' },
      { 'first': 'first4', 'second': 'second4', 'third': 'third4' }
    ];
  }
}
interface MyModel {
  first: string;
  second: string;
  third: string;
}
