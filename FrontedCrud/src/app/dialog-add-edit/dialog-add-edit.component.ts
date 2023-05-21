import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Trabajador } from '../interfaces/trabajador';
import { TrabajadorService } from '../Service/trabajador.service';
import { MatSnackBar } from "@angular/material/snack-bar";


@Component({
  selector: 'app-dialog-add-edit',
  templateUrl: './dialog-add-edit.component.html',
  styleUrls: ['./dialog-add-edit.component.css'],
  providers: []
})
export class DialogAddEditComponent implements OnInit {
  public formGroup: FormGroup;
  title: string = "Nuevo";
  accion: string = "Agregar";
  constructor(
    private dialogReferencia: MatDialogRef<DialogAddEditComponent>,
    private fb: FormBuilder,
    private _snackBar: MatSnackBar,
    private _trabajadorService: TrabajadorService,
    @Inject(MAT_DIALOG_DATA) public t: Trabajador,
  ) {
    this.formGroup = this.fb.group({
      documentoIdentidad: ['', Validators.required],
      nombres: ['', Validators.required],
      telefono: ['', Validators.required],
      correo: ['', Validators.required],
      ciudad: ['',Validators.required]
    });
  }

  mostrarAlerta(message: string, action: string) {
    this._snackBar.open(message, action, {horizontalPosition:"end", verticalPosition:"top", duration: 3000});
  }

  addEditEmpleado(event: Event){
    event.preventDefault();
    console.log(this.formGroup.value);
    const trabajador: Trabajador = {
      "documentoIdentidad": this.formGroup.value.documentoIdentidad,
      "nombres": this.formGroup.value.nombres,
      "telefono": this.formGroup.value.telefono,
      "correo": this.formGroup.value.correo,
      "ciudad": this.formGroup.value.ciudad,
    }

    if (this.t == null){
          this._trabajadorService.postOne(trabajador).subscribe({
            next: (data) => {
              this.mostrarAlerta("Empleado fue creado", "listo");
              this.dialogReferencia.close("Creado");
            },error: (err) => {
              this.mostrarAlerta("No se pudo crear", "Error");
            }
          });
          return;
    }
    this._trabajadorService.putOne(this.t.idUsuario!, trabajador).subscribe({
      next: (data) => {
        this.mostrarAlerta("Empleado fue Modificado", "listo");
        this.dialogReferencia.close("Editado");
      },error: (err) => {
        this.mostrarAlerta("No se pudo crear", "Error");
      }
    });
  }

  ngOnInit(): void {
    if (this.t){
      this.formGroup.patchValue({
        nombres: this.t.nombres,
        documentoIdentidad: this.t.documentoIdentidad,
        telefono: this.t.telefono,
        correo: this.t.correo,
        ciudad: this.t.ciudad
      });
      this.title = "Editar";
      this.accion = "Guardar"
    }
  }
}
