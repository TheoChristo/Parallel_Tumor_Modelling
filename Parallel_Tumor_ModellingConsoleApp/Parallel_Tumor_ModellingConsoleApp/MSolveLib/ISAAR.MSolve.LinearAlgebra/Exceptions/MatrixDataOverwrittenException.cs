﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ISAAR.MSolve.LinearAlgebra.Exceptions
{
    /// <summary>
    /// The exception that is thrown when using operations on a matrix whose internal data have been overwritten due to 
    /// factorization or inversion.
    /// Authors: Serafeim Bakalakos
    /// </summary>
    public class MatrixDataOverwrittenException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixDataOverwrittenException"/> class.
        /// </summary>
        public MatrixDataOverwrittenException()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixDataOverwrittenException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public MatrixDataOverwrittenException(string message) : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixDataOverwrittenException"/> class with a specified error message 
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception. If the innerException parameter is not 
        ///     a null reference, the current exception is raised in a catch block that handles the inner exception. </param>
        public MatrixDataOverwrittenException(string message, Exception inner) : base(message, inner)
        { }
    }
}
