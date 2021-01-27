import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AdminService } from '../../_services/admin.service';

@Component({
    selector: 'app-topics',
    templateUrl: './topics.component.html',
    styleUrls: ['./topics.component.css']
})
/** topics component*/
export class TopicsComponent implements OnInit {
  topics: any;
  topicForm: FormGroup;
    /** topics ctor */
  constructor(
    private adminService: AdminService,
    private formBuilder: FormBuilder
  ) {

    }
  ngOnInit(): void {

    this.topicForm = this.formBuilder.group({
      name: ['']
    });
    this.adminService.GetTopics().subscribe(res => {
      this.topics = res;
      console.log(this.topics);

    }, error => {
      console.log(error);
    });
  }

  addTopic() {
    this.adminService.SaveTopic(this.topicForm.get('name').value).subscribe(res => {
      if (res) {
        this.topicForm.get('name').setValue("");
        this.adminService.GetTopics().subscribe(res => {
          this.topics = res;
          console.log(this.topics);

        }, error => {
          console.log(error);
        });
      }
    }, error => {
        console.log(error);
    })
  }
}
