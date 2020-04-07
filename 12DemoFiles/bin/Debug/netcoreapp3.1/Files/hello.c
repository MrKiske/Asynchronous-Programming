// hello.c - Hello World with MPI
// compile: mpicc -Wall -O -o hello hello.c
// run:     mpirun -np num_procs hello

#include <stdio.h>
#include <mpi.h>

int main(int argc, char ** argv)
{
  int p;                                // size
  int id;                               // rank

  MPI_Init(&argc, &argv);               // start up "virtual machine"
  MPI_Comm_size(MPI_COMM_WORLD, &p);    // get size of VM
  MPI_Comm_rank(MPI_COMM_WORLD, &id);   // get own rank in VM

  printf("Hola Cristian. Yo soy Alexis Rojas %d of %d\n", id, p);     // payload

  MPI_Finalize();                       // shut down VM
  return 0;
}
