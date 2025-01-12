namespace WPFetch.Model.System
{
    public enum SystemOptions
    {
        /// <summary>
        /// The name and version of the operating system
        /// </summary>
        OperatingSystem,

        /// <summary>
        /// The name and version of the Kernel
        /// </summary>
        Kernel,

        /// <summary>
        /// The name of the machine
        /// </summary>
        MachineName,

        /// <summary>
        /// Is the OS in 64bit
        /// </summary>
        Is64Bit,

        /// <summary>
        /// The storage of the machine 
        /// </summary>
        Storage,

        /// <summary>
        /// Number of CPU threads
        /// </summary>
        CPUThreads,

        /// <summary>
        /// Processor name
        /// </summary>
        Processor,

        /// <summary>
        /// Listes of GPUs (@GPUModel)
        /// </summary>
        GPUs,

        /// <summary>
        /// The total capacity of Physical RAM (Read only memory)
        /// </summary>
        RAM,

        /// <summary>
        /// The numbers of the processes running
        /// </summary>
        NumberOfProcessRunning,

        /// <summary>
        /// The battery percentage
        /// </summary>
        BatteryPercentage
    }
}
