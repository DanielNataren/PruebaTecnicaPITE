import { AfterViewInit, Component, OnInit } from '@angular/core';
import { TrabajadorService } from './Service/trabajador.service';
import { Trabajador } from './interfaces/trabajador';
import {MatDialog} from '@angular/material/dialog'
import { DialogAddEditComponent } from './dialog-add-edit/dialog-add-edit.component';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'FrontedCrud';
  public trabajadores: Trabajador[] = [];
  constructor(
    private _trabajadorService: TrabajadorService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.showEmployers();
  }

  dialogEditEmpleado(t: Trabajador){
    this.dialog.open(DialogAddEditComponent, {
      disableClose: true,
      width: "500px",
      data: t
    })
    .afterClosed().subscribe(r => {
      if (r === "Editado"){
        this.showEmployers();
      }
    });
  }

  openDialog() {
    this.dialog.open(DialogAddEditComponent, {
      disableClose: true,
      width: "500px"
    })
    .afterClosed().subscribe(r => {
      if (r === "Creado"){
        this.showEmployers();
      }
    });
  }

  handledDelete(id: number){
    this._trabajadorService.deleteOne(id).subscribe({
      next: () => {
        this.trabajadores = this.trabajadores.filter(t => t.idUsuario != id);
      },
      error: (error) => {
        console.log(error.error.text)
        if (error.error.text.includes("eliminado")){
          this.trabajadores = this.trabajadores.filter(t => t.idUsuario != id);
          console.log(this.trabajadores)
        }
      },
      complete: () => {
        this.trabajadores = this.trabajadores.filter(t => t.idUsuario != id);
      },
    });
  }

  showEmployers(){
    this._trabajadorService.getTrabajadores().subscribe({
      next: (data)=> {
        this.trabajadores = data;
      },
      error: (error) => {}
    });
  }



}
